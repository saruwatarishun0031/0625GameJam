using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("���[���̐� (1�ȉ��ɂ��Ă͂����Ȃ�)")]
    float laneValue;
    [SerializeField, Tooltip("����")]
    float weight;

    [SerializeField, Tooltip("�������鎞�ԊԊu")]
    float _interval;
    float _intervalTimer;

    [SerializeField, Tooltip("��������A�C�e��")]
    GameObject[] _items;


    void Start()
    {
        
    }

    void Update()
    {
        if (_intervalTimer + _interval < Time.time)
        {
            _intervalTimer = Time.time;
            ItemGenerate();
        }
    }

    void ItemGenerate()
    {
        int randomIndexItem = Random.Range(0, _items.Length);
        int randomIndexPosX = Random.Range(0, (int)laneValue);

        float x = transform.position.x - weight / 2 + weight / (laneValue - 1) * randomIndexPosX ;

        Instantiate(_items[randomIndexItem], transform.position + Vector3.right * x, Quaternion.identity);
    }
}
