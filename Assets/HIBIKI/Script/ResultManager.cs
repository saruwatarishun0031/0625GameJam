using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    string _loadScene;

    [SerializeField]
    Text[] _scoreText;
    float[] _scoreArray = new float[4];



    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        _scoreArray[3] = ScoreManager.ScoreTotal;

        Array.Sort(_scoreArray);
        Array.Reverse(_scoreArray);
        float[] topThreeScore = _scoreArray.Take(3).ToArray();

        for (int i = 0; i < 3; i++)
        {
            _scoreText[i].text = Mathf.FloorToInt(topThreeScore[i]).ToString("D5");
        }
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(EndResult());
        }
    }

    IEnumerator EndResult()
    {
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        ScenechangeManager.Instance.LoadSceme(_loadScene);
    }
}
