Shader "Unlit/Picro"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "gray" {}
        _ShadowColor ("ShadowColor", Color) = (0, 0, 0, 1)
        _ShadowRange ("ShadowRange", Range (-2, 1)) = 0
        _LightColor ("LightColor", Color) = (1, 1, 1, 1)
        _LightRange ("LightRange", Range (-1, 2)) = -1
        _AnimeShadowColor ("AnimeShadowColor", Color) = (0, 0, 0, 1)
        _AnimeShadowRange ("AnimeShadowRange", Range (-1, 1)) = -1
        _AnimeLightColor ("AnimeLightColor", Color) = (1, 1, 1, 1)
        _AnimeLightRange ("AnimeLightRange", Range (-1, 1)) = -1
        _DropShadowColor ("DropShadowColor", Color) = (0, 0, 0, 1)
        _DropShadowStrength ("DropShadowStrength", Range (0, 1)) = 1
        _BumpMap ("NormalMap", 2D) = "bump" {}
        _AmbientColor ("AmbientColor", Color) = (1, 1, 1, 1)
        _Metaric ("Metaric", Range (0, 1)) = 0
        _AirColor ("AirColor", Color) = (1, 1, 1, 1)
        _AirDirty ("AirDirty", Range (0, 99.9)) = 0
        _Fog ("Fog", Range (0, 1)) = 0
        _Like3D ("Like3D", Range (0, 1)) = 1
        _LimColor ("LimColor", Color) = (1, 1, 1, 1)
        _LimRange ("LimRange", Range (0, 0.99)) = 0
        _OriginColor ("OriginColor", Range (0, 1)) = 0
        _OutlineColor ("OutlineColor", Color) = (0, 0, 0, 1)
        _OutlineSize ("OutlineSize", Range (0, 1)) = 0
        _OutlineShadowColor ("OutlineShadowColor", Color) = (0, 0, 0, 1)
        _OutlineShadowRange ("OutlineShadowRange", Range (-1, 1)) = 0
        _OutlineLightColor ("OutlineLightColor", Color) = (1, 1, 1, 1)
        _OutlineLightRange ("OutlineLightRange", Range (-1, 1)) = -1
    }
    SubShader
    {
        Tags { "Queue"="Background" }
        LOD 100
        Cull Off

        Pass
        {
            Tags {"LightMode"="ForwardBase"}
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            struct appdata
            {
                fixed4 vertex : POSITION;
                fixed2 uv : TEXCOORD0;
                fixed3 normal : NORMAL;
                fixed4 tangent : TANGENT;
            };

            struct v2f
            {
                fixed4 pos : SV_POSITION;
                fixed3 worldPos : TEXCOORD0;
                fixed2 uv : TEXCOORD1;
                fixed3 normal : TEXCOORD2;
                fixed3 tangent : TEXCOORD3;
                fixed3 binormal : TEXCOORD4;
                SHADOW_COORDS(5)
            };

            sampler2D _MainTex;
            fixed4 _MainTex_ST;
            fixed4 _ShadowColor;
            fixed _ShadowRange;
            fixed4 _LightColor;
            fixed _LightRange;
            fixed4 _AnimeShadowColor;
            fixed _AnimeShadowRange;
            fixed4 _AnimeLightColor;
            fixed _AnimeLightRange;
            fixed4 _DropShadowColor;
            fixed _DropShadowStrength;
            sampler2D _BumpMap;
            fixed4 _BumpMap_ST;
            fixed4 _AmbientColor;
            fixed _Metaric;
            fixed4 _AirColor;
            fixed _AirDirty;
            fixed _Fog;
            fixed _Like3D;
            fixed4 _LimColor;
            fixed _LimRange;
            fixed _OriginColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.tangent = normalize(mul(unity_ObjectToWorld, v.tangent)).xyz;
                o.binormal = cross(v.normal, v.tangent) * v.tangent.w;
                o.binormal = normalize(mul(unity_ObjectToWorld, o.binormal));
                TRANSFER_SHADOW(o)
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed3 normalmap = UnpackNormal(tex2D(_BumpMap, i.uv));
                fixed3 Normal = (i.tangent * normalmap.x) + (i.binormal * normalmap.y) + (i.normal * normalmap.z);
                fixed4 diff = (1 - (1 - min(1, abs(max(0, dot(Normal, _WorldSpaceLightPos0.xyz) - _ShadowRange)))) * (1 - _ShadowColor)) * _LightColor0;
                fixed4 light =  min(1, abs(max(0, dot(Normal, _WorldSpaceLightPos0.xyz) + _LightRange))) * _LightColor;
                fixed4 animeDiff = 1 - abs(step(dot(Normal, _WorldSpaceLightPos0.xyz), _AnimeShadowRange)) * (1 - _AnimeShadowColor);
                fixed4 animeLight = abs(step(-_AnimeLightRange, dot(-Normal, -_WorldSpaceLightPos0.xyz))) * _AnimeLightColor;
                fixed4 shadow = 1 - (1 - SHADOW_ATTENUATION(i)) * (1 - _DropShadowColor) * _DropShadowStrength;
                fixed4 lighting = (diff * animeDiff + light + animeLight) * shadow;
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 save = col;
                col = 1.0 - col;
                lighting -= col;
                lighting.r *= step(0, lighting.r);
                lighting.g *= step(0, lighting.g);
                lighting.b *= step(0, lighting.b);
                fixed4 ambient = _AmbientColor - col;
                ambient.r *= step(0, ambient.r);
                ambient.g *= step(0, ambient.g);
                ambient.b *= step(0, ambient.b);
                fixed4 far = distance(_WorldSpaceCameraPos, i.worldPos);
                far = far / (100 - _AirDirty) * _AirColor;
                far.r = 1 - step(far.r, 1) * (1 - far.r);
                far.g = 1 - step(far.g, 1) * (1 - far.g);
                far.b = 1 - step(far.b, 1) * (1 - far.g);
                col = lighting + ambient;
                col *= abs(dot(UNITY_MATRIX_V[2].xyz, Normal)) * _Metaric + 1;
                col *= abs(dot(UNITY_MATRIX_V[2].xyz, Normal)) * _Like3D + 1;
                col += (max(0, (1 - abs(dot(UNITY_MATRIX_V[2].xyz, Normal))) - (1 - _LimRange))) / (1 - _LimRange) * _LimColor;
                far = 1 - (1 - far) * (1 - col);
                col = col * (1 - _Fog) + far * _Fog;
                col = col * (1 - _OriginColor) + save * _OriginColor;
                return col;
            }
            ENDCG
        }

        Pass
        {
            Tags {"LightMode"="ForwardAdd"}
            Blend One One
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            struct appdata
            {
                fixed4 vertex : POSITION;
                fixed2 uv : TEXCOORD1;
                fixed3 normal : NORMAL;
                fixed4 tangent : TANGENT;
            };

            struct v2f
            {
                fixed4 pos : SV_POSITION;
                fixed3 worldPos : TEXCOORD0;
                fixed2 uv : TEXCOORD1;
                fixed3 normal : TEXCOORD2;
                fixed3 tangent : TEXCOORD3;
                fixed3 binormal : TEXCOORD4;
                SHADOW_COORDS(5)
            };

            sampler2D _MainTex;
            fixed4 _MainTex_ST;
            sampler2D _BumpMap;
            fixed4 _BumpMap_ST;
            fixed _Metaric;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.tangent = normalize(mul(unity_ObjectToWorld, v.tangent)).xyz;
                o.binormal = cross(v.normal, v.tangent) * v.tangent.w;
                o.binormal = normalize(mul(unity_ObjectToWorld, o.binormal));
                TRANSFER_SHADOW(o)
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed3 normalmap = UnpackNormal(tex2D(_BumpMap, i.uv));
                fixed3 Normal = (i.tangent * normalmap.x) + (i.binormal * normalmap.y) + (i.normal * normalmap.z);
                fixed nl = distance(i.worldPos, _WorldSpaceLightPos0.xyz);
                fixed nll = abs(max(0, dot(Normal, normalize(_WorldSpaceLightPos0.xyz - i.worldPos))));
                fixed4 diff = 1 / (1 + nl) / (1 + nl) * nll * _LightColor0;
                fixed shadow = SHADOW_ATTENUATION(i);
                fixed4 lighting = diff * shadow;
                fixed4 col = tex2D(_MainTex, i.uv);
                col = 1.0 - col;
                lighting -= col;
                lighting.r *= step(0, lighting.r);
                lighting.g *= step(0, lighting.g);
                lighting.b *= step(0, lighting.b);
                col = lighting;
                return col;
            }
            ENDCG
        }

        Pass
        {
            Tags {"LightMode"="ShadowCaster"}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_shadowcaster
            #include "UnityCG.cginc"

            struct v2f
            {
                V2F_SHADOW_CASTER;
            };

            v2f vert(appdata_base v)
            {
                v2f o;
                TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
    }
}