using UnityEngine;

public class ItemMoveController : MonoBehaviour
{
    Vector3 _firstPos;

    [SerializeField, Tooltip("�c�̈ړ����x")]
    float _dropSpeed;

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

        transform.position = new Vector3(Mathf.Cos(_theta) * _swingValue, transform.position.y, transform.position.z);
        transform.Translate(Vector3.down * _dropSpeed * Time.deltaTime);

    }
}
