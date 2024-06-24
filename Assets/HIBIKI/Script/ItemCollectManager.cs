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


    void Start()
    {
        _getScoreValue = _getScore;
    }


    void Update()
    {

    }

    public static void ResetCollect()
    {
        _collectHA = _collectNA = _collectSU = false;
        Debug.Log("コレクトをリセット");
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
                CollectSuccess();
                break;

            case ItemKind.na:
                if (_collectNA)
                {
                    CollectFailed();
                    break;
                }

                _collectNA = true;
                CollectSuccess();
                break;

            case ItemKind.su:
                if (_collectSU)
                {
                    CollectFailed();
                    break;
                }

                _collectSU = true;
                CollectSuccess();
                break;

            case ItemKind.hana:
                if (_collectHA || _collectNA)
                {
                    CollectFailed();
                    break;
                }

                _collectHA = _collectNA = true;
                CollectSuccess();
                break;

            case ItemKind.nasu:
                if (_collectNA || _collectSU)
                {
                    CollectFailed();
                    break;
                }

                _collectNA = _collectSU = true;
                CollectSuccess();
                break;
            case ItemKind.hasu:
                if (_collectHA || _collectSU)
                {
                    CollectFailed();
                    break;
                }

                _collectHA = _collectSU = true;
                CollectSuccess();
                break;
        }

    }

    static void CollectSuccess()
    {

        if (_collectHA)
        {
            Debug.Log("は");
        }

        if (_collectNA)
        {
            Debug.Log("な");
        }

        if (_collectSU)
        {
            Debug.Log("す");
        }

        ScoreManager.GetScore(_getScoreValue);

        if (_collectHA && _collectNA && _collectSU)
        {
            ResetCollect();
        }
    }

    static void CollectFailed()
    {
        Debug.Log("間違えた");
    }

}
