using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("レーンの数 (1以下にしてはいけない)")]
    float laneValue;
    [SerializeField, Tooltip("横幅")]
    float weight;

    [SerializeField, Tooltip("生成する時間間隔")]
    float _interval;
    float _intervalTimer;

    [SerializeField, Tooltip("生成するアイテム")]
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
