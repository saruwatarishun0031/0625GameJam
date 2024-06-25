using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class SceneChenge : MonoBehaviour
{
    //[SerializeField] ScoreScript scoreScript;//���O���u��
    [SerializeField] Text[] ScoreText = new Text[3];

    
    
    [SerializeField] private AudioSource Result;
    static float[] scoreArrey = new float[4];

   
    void Start()
    {
        scoreArrey[3] = ScoreManager.ScoreTotal;
        for (int i = 0;i<3;i++)
        {
            Debug.Log(scoreArrey[i]);
        }
        
        Array.Sort(scoreArrey);
        Array.Reverse(scoreArrey);
        float[] TopThreeScore = scoreArrey.Take(3).ToArray();
        

        for (int i = 0; i < 3; i++) 
        {
            ScoreText[i].text = TopThreeScore[i].ToString();
            Debug.Log(TopThreeScore[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            Debug.Log("�V�[���ړ�");
            Result.Play();
            StartCoroutine(LoadScene());
            
        }
    }
    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        //�^�C�g���V�[���̖��O������B
        ScenechangeManager.Instance.LoadSceme("Title");
    }
}
