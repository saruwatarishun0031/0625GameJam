using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    static float _scoreTotal;
    public static float ScoreTotal { get { return _scoreTotal; } }

    static TextMeshProUGUI ScoreText;

    void Start()
    {
        _scoreTotal = 0;

        ScoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void GetScore(float score)
    {
        _scoreTotal = Mathf.Max(_scoreTotal + score, 0);

        Debug.Log(_scoreTotal);

        ScoreText.text = $"Score : {Mathf.FloorToInt(_scoreTotal).ToString("D5")}";
    }
}
