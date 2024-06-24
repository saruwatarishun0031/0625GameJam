using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenechangeManager : MonoBehaviour
{

    //シングルトンパターン（簡易型、呼び出される）
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
    //シングルトン（ここまで）
    // Start is called before the first frame update

    public void LoadSceme(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
