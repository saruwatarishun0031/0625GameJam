
using UnityEngine;
using UnityEngine.SceneManagement;


public class Startbutton : MonoBehaviour
{
    public class SceneLoader : MonoBehaviour //SceneLoader‚Æ‚¢‚¤–¼‘O‚É‚µ‚Ü‚·
    {
        public void Start_button(string Sceneneme) //string_button‚Æ‚¢‚¤–¼‘O‚É‚µ‚Ü‚·
        {
            SceneManager.LoadScene(Sceneneme);//second‚ğŒÄ‚Ño‚µ‚Ü‚·
        }
    }
}

