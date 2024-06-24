using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using DG.Tweening;
using UnityEngine.UI;


public class Fade : MonoBehaviour
{
    [SerializeField] Image _target;

    //�V���O���g���p�^�[���i�ȈՌ^�A�Ăяo�����j
    public static Fade Instance;

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


    public void Fadeout()
    {
        _target.DOFade(0f, 3f);
    }
    public void Fadein()
    {
        _target.DOColor(new Color(0, 0, 0, 1f), 1.5f);
    }
}
