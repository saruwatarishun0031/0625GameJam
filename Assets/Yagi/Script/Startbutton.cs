
using UnityEngine;
using UnityEngine.SceneManagement;


public class Startbutton : MonoBehaviour
{
    public class SceneLoader : MonoBehaviour //SceneLoader�Ƃ������O�ɂ��܂�
    {
        public void Start_button(string Sceneneme) //string_button�Ƃ������O�ɂ��܂�
        {
            SceneManager.LoadScene(Sceneneme);//second���Ăяo���܂�
        }
    }
}

