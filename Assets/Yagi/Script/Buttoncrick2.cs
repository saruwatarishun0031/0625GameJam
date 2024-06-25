using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttoncrick2 : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Playaudio()
    {
        audioSource.Play();
    }
}
