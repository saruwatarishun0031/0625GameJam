using UnityEngine;

public class ItemCollectManager : MonoBehaviour
{
    public enum ItemKind
    {
        ha,
        na,
        su,
        hana,
        nasu,
        hasu
    }

    static bool _collectHA;
    static bool _collectNA;
    static bool _collectSU;


    [SerializeField]
    float _getScore;

    static float _getScoreValue;

    static bool _miss;


    void Start()
    {
        _getScoreValue = _getScore;
        ResetCollect();
    }


    void Update()
    {

    }

    public static void ResetCollect()
    {
        _collectHA = _collectNA = _collectSU = false;
        _miss = false;
        Debug.Log("�R���N�g�����Z�b�g");
    }

    public static void CollectItem(ItemKind kind)
    {
        switch (kind)
        {
            case ItemKind.ha:
                if (_collectHA)
                {
                    CollectFailed();
                    break;
                }

                _collectHA = true;
                Collect();
                break;

            case ItemKind.na:
                if (_collectNA)
                {
                    CollectFailed();
                    break;
                }

                _collectNA = true;
                Collect();
                break;

            case ItemKind.su:
                if (_collectSU)
                {
                    CollectFailed();
                    break;
                }

                _collectSU = true;
                Collect();
                break;

            case ItemKind.hana:
                if (_collectHA || _collectNA)
                {
                    CollectFailed();
                    break;
                }

                _collectHA = _collectNA = true;
                Collect();
                break;

            case ItemKind.nasu:
                if (_collectNA || _collectSU)
                {
                    CollectFailed();
                    break;
                }

                _collectNA = _collectSU = true;
                Collect();
                break;
            case ItemKind.hasu:
                if (_collectHA || _collectSU)
                {
                    CollectFailed();
                    break;
                }

                _collectHA = _collectSU = true;
                Collect();
                break;
        }

    }

    static void Collect()
    {

        if (_collectHA)
        {
            Debug.Log("��");
        }

        if (_collectNA)
        {
            Debug.Log("��");
        }

        if (_collectSU)
        {
            Debug.Log("��");
        }
    }

    static void CollectFailed()
    {
        Debug.Log("�ԈႦ��");
        _miss = true;
    }

    public static void Verification()
    {
        if (_collectHA && _collectNA && _collectSU && !_miss)
        {
            ScoreManager.GetScore(_getScoreValue);
            Debug.Log("����");
        }

        ResetCollect();
    }

}
