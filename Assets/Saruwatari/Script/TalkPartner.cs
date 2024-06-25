using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TalkPartner : MonoBehaviour
{

    [SerializeField]
    ItemCollectManager.ItemKind _thisItemKind;
    [SerializeField, Header("�ړ����鎞��")]
    float _time = 1f;
    [SerializeField, Header("y���W")]
    float Y;
    [SerializeField, Header("���ڂ�y���W")]
    float Y2;
    [SerializeField, Header("X���W")]
    float X = 8.28f;



    private void Start()
    {
        ItemCollectManager.CollectItem(_thisItemKind);
        transform.DOLocalMove(new Vector3(X, Y, 0), _time);
    }
    
    private void Update()
    {
        if (TalkJudgement.Instance._success == true)
        {
            Exit();
            Debug.Log("��΂ꂽ��");
        }
    }

    public void Exit()
    {
        
        transform.DOLocalMove(new Vector3(X, Y2, 0), _time);
        //TalkJudgement.Instance.Spawn();
        //TalkJudgement.Instance._success = false;
        //TalkJudgement.Instance._failure = false;
        //StartCoroutine(BoolSwitch());

        Destroy(this.gameObject,2f);
        //Debug.Log(TalkJudgement.Instance._Success);


    }

    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Destruction")
        {
            Debug.Log("�j��");
            Destroy(this.gameObject);
        }
    }

}
