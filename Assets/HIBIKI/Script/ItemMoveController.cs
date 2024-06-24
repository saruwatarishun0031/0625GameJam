using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMoveController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    ItemCollectManager.ItemKind _thisItemKind;

    [SerializeField, Tooltip("�c�̈ړ����x")]
    float _dropSpeed;

    Vector3 _firstPos;

    [Space]

    [SerializeField, Tooltip("���h��̑��x")]
    float _swingSpeed;
    [SerializeField, Tooltip("���h��̑傫��")]
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
        Debug.Log("�N���b�N���ꂽ");

        ItemCollectManager.CollectItem(_thisItemKind);

        Destroy(gameObject);
    }
}
