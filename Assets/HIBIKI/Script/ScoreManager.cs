using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static float _scoreTotal;
    public float ScoreTotal { get { return _scoreTotal; } }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void GetScore(float score)
    {
        _scoreTotal += score;
    }
}
