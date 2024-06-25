using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG;

public class TalkJudgement : MonoBehaviour
{
    ItemCollectManager.ItemKind _thisItemKind;

    public List<GameObject> _talkPartner = new List<GameObject>();

    [SerializeField]
    GameObject pos;

    [SerializeField, Header("次に行きたいシーンの名前")]
    string _SceneNemu;
    [SerializeField, Header("シーン移動に待ってほしい時間")]
    float _waitTime;
    [SerializeField, Header("話すテキスト")]
    Text _talkText;
    [SerializeField, Header("タイマーテキスト")]
    Text _timerText;
    [SerializeField, Header("タイマー")]
    float _timer;

    
    public bool _Success = false;
    public bool _Failure = false;



    public List<TextChildList> testList = new List<TextChildList>();


    //シングルトンパターン（簡易型、呼び出される）
    public static TalkJudgement Instance;

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

    // Start is called before the first frame update
    void Start()
    {
        // テストデータの初期化
        TextList take = new TextList("Take", 1);


        TextChildList childList1 = new TextChildList(new List<TextList> { take });

        testList.Add(childList1);

        int x = Random.Range(0, 6);
        Instantiate(_talkPartner[x], pos.transform.position, Quaternion.identity);
        _Success = false;
        _Failure = false;

    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        Message();
        Spawn();
    }

    void Timer()
    {
        if (_timer < 0)
        {
            StartCoroutine(WaitLoad());
            return;
        }
        _timer -= Time.deltaTime;
        if (_timerText)
        {
            _timerText.text = Mathf.Round(_timer).ToString();
        }
    }


    void Message()
    {
        if (_thisItemKind == ItemCollectManager.ItemKind.ha)
        {
            TalkMessage(testList[0].list, 0);
            if (_Success == true)
            {
                TalkMessage(testList[0].list, 1);
                
            }
            else if (_Failure == true)
            {
                TalkMessage(testList[0].list, 2);
            }
        }
        if (_thisItemKind == ItemCollectManager.ItemKind.hana)
        {
            TalkMessage(testList[1].list, 0);
            if (_Success == true)
            {
                TalkMessage(testList[1].list, 1);
                
            }
            else if (_Failure == true)
            {
                TalkMessage(testList[2].list, 2);
            }
        }
        if (_thisItemKind == ItemCollectManager.ItemKind.hasu)
        {
            TalkMessage(testList[2].list, 0);
            if (_Success == true)
            {
                TalkMessage(testList[2].list, 1);
                
            }
            else if (_Failure == true)
            {
                TalkMessage(testList[2].list, 2);
            }
        }
        if (_thisItemKind == ItemCollectManager.ItemKind.na)
        {
            TalkMessage(testList[3].list, 0);
            if (_Success == true)
            {
                TalkMessage(testList[3].list, 1);
                
            }
            else if (_Failure == true)
            {
                TalkMessage(testList[3].list, 2);
            }
        }
        if (_thisItemKind == ItemCollectManager.ItemKind.nasu)
        {
            TalkMessage(testList[4].list, 0);
            if (_Success == true)
            {
                TalkMessage(testList[4].list, 1);
            }
            else if (_Failure == true)
            {
                TalkMessage(testList[4].list, 2);
            }
        }
        if (_thisItemKind == ItemCollectManager.ItemKind.su)
        {
            TalkMessage(testList[5].list, 0);
            if (_Success == true)
            {
                TalkMessage(testList[5].list, 1);
            }
            else if (_Failure == true)
            {
                TalkMessage(testList[5].list, 2);
                
            }
        }
    }

    public void Spawn()
    {
        if (_Success == true)
        {
            int x = Random.Range(0, 6);
            Instantiate(_talkPartner[x], pos.transform.position, Quaternion.identity);
            
            
           
        }
    }

    public void TalkMessage(List<TextList> list, int index)
    {
        TextList myList = list[index];
        _talkText.text = myList.text;
    }

    private IEnumerator WaitLoad()
    {
        yield return new WaitForSeconds(_waitTime);
        ScenechangeManager.Instance.LoadSceme(_SceneNemu);
    }

    
}
