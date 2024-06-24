using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class SceneChenge : MonoBehaviour
{
    //[SerializeField] ScoreScript scoreScript;//名前仮置き
    [SerializeField] Text[] ScoreText = new Text[3];

    
    
    [SerializeField] private AudioSource Result;
    static float[] scoreArrey = new float[4];

    float _scoreTptal;

    void Start()
    {
        scoreArrey = new float[4];
        scoreArrey[3] = _scoreTptal;
        
        Array.Sort(scoreArrey);
        Array.Reverse(scoreArrey);
        float[] TopThreeScore = scoreArrey.Take(3).ToArray();

        for (int i = 0; i < 3; i++) 
        {
            ScoreText[i].text = TopThreeScore[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            Debug.Log("シーン移動");
            Result.Play();
            StartCoroutine(LoadScene());
            
        }
    }
    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        //タイトルシーンの名前を入れる。
        ScenechangeManager.Instance.LoadSceme("RENTAscene");
    }
}
