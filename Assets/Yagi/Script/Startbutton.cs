
using UnityEngine;
using UnityEngine.SceneManagement;


public class Startbutton : MonoBehaviour
{
    public class SceneLoader : MonoBehaviour //SceneLoaderという名前にします
    {
        public void Start_button(string Sceneneme) //string_buttonという名前にします
        {
            SceneManager.LoadScene(Sceneneme);//secondを呼び出します
        }
    }
}

