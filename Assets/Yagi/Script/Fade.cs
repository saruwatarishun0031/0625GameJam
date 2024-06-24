using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using DG.Tweening;
using UnityEngine.UI;


public class Fade : MonoBehaviour
{
    [SerializeField] Image _target;

    //シングルトンパターン（簡易型、呼び出される）
    public static Fade Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    //シングルトン（ここまで）
    // Start is called before the first frame update


    public void Fadeout()
    {
        _target.DOFade(0f, 3f);
    }
    public void Fadein()
    {
        _target.DOColor(new Color(0, 0, 0, 1f), 1.5f);
    }
}
