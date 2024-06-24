using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMoveController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    ItemCollectManager.ItemKind _thisItemKind;

    [SerializeField, Tooltip("縦の移動速度")]
    float _dropSpeed;

    Vector3 _firstPos;

    [Space]

    [SerializeField, Tooltip("横揺れの速度")]
    float _swingSpeed;
    [SerializeField, Tooltip("横揺れの大きさ")]
    float _swingValue;

    float _theta;
    void Start()
    {
        _firstPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _theta = (_theta + (_swingSpeed * Time.deltaTime)) % 360;

        transform.position = new Vector3(Mathf.Cos(_theta) * _swingValue + _firstPos.x, -_dropSpeed * Time.deltaTime + transform.position.y, _firstPos.z);
    }

    public void OnPointerClick(PointerEventData data)
    {
        Debug.Log("クリックされた");

        ItemCollectManager.CollectItem(_thisItemKind);

        Destroy(gameObject);
    }
}
