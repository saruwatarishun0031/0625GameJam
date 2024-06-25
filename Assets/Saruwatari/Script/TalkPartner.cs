using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TalkPartner : MonoBehaviour
{

    [SerializeField]
    ItemCollectManager.ItemKind _thisItemKind;
    [SerializeField,Header("移動する時間")]
    float _time;
    [SerializeField, Header("y座標")]
    float Y;
    [SerializeField, Header("y座標")]
    float Y2;



    private void Start()
    {
        ItemCollectManager.CollectItem(_thisItemKind);
        transform.DOLocalMove(new Vector3(8.28f, Y, 0), 1f);
    }

    private void Update()
    {
        if (TalkJudgement.Instance._Success == true)
        {
            Exit();
            Debug.Log("飛ばれたよ");
        }
    }

    public void Exit()
    {
        
            transform.DOLocalMove(new Vector3(8.28f, Y2, 0), 1f);
        TalkJudgement.Instance._Success = false;
        TalkJudgement.Instance._Failure = false;
        Destroy(this.gameObject,2f);
        //Debug.Log(TalkJudgement.Instance._Success);


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Destruction")
        {
            Debug.Log("破壊");
            Destroy(this.gameObject);
        }
    }

}
