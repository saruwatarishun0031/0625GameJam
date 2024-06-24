using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject _button1;
    [SerializeField] GameObject _button2;
    [SerializeField] GameObject _titletext;
    [SerializeField] GameObject _explanation;
    [SerializeField] GameObject _flower;
    [SerializeField] GameObject _flower2;
    [SerializeField] GameObject _image3;
    [SerializeField] GameObject _image4;
    [SerializeField] GameObject _image5;
    [SerializeField] GameObject _image6;
    AudioSource audioSource;
    void Start()
    {
      audioSource = GetComponent<AudioSource>();
    }
    

    public void Test()
    {
        _flower.SetActive(false);
        _image3.SetActive(false);
        _image5.SetActive(false);
        _titletext.SetActive(false);
        _explanation.SetActive(true);
        _button1.SetActive(false);
        _button2.SetActive(true);
        _flower2.SetActive(true);
        _image4.SetActive(true);
        _image6.SetActive(true);
        audioSource.Play();
    }
}