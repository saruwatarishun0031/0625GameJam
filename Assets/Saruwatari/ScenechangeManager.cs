using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenechangeManager : MonoBehaviour
{

    //�V���O���g���p�^�[���i�ȈՌ^�A�Ăяo�����j
    public static ScenechangeManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    //�V���O���g���i�����܂Łj
    // Start is called before the first frame update

    public void LoadSceme(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
