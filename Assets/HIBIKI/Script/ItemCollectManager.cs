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
    GameObject[] _wordImages;

    static GameObject _imageHA;
    static GameObject _imageNA;
    static GameObject _imageSU;


    [SerializeField]
    float _getScore;

    static float _getScoreValue;

    static bool _miss;

    


    void Start()
    {
        
        _getScoreValue = _getScore;

        _imageHA = _wordImages[0];
        _imageNA = _wordImages[1];
        _imageSU = _wordImages[2];

        ResetCollect();
    }


    void Update()
    {

    }

    public static void ResetCollect()
    {
        _collectHA = _collectNA = _collectSU = false;

        _imageHA.SetActive(false);
        _imageNA.SetActive(false);
        _imageSU.SetActive(false);

        _miss = false;

        Debug.Log("コレクトをリセット");
    }

    public static void CollectItem(ItemKind kind)
    {
        switch (kind)
        {
            case ItemKind.ha:
                _collectHA = !_collectHA;
                _imageHA.SetActive(_collectHA);
                Collect();
                break;

            case ItemKind.na:
                _collectNA = !_collectNA;
                _imageNA.SetActive(_collectNA);
                Collect();
                break;

            case ItemKind.su:
                _collectSU = !_collectSU;
                _imageSU.SetActive(_collectSU);
                Collect();
                break;

            case ItemKind.hana:
                _collectHA = !_collectHA;
                _collectNA = !_collectNA;
                _imageHA.SetActive(_collectHA);
                _imageNA.SetActive(_collectNA);
                Collect();
                break;

            case ItemKind.nasu:
                _collectNA = !_collectNA;
                _collectSU = !_collectSU;
                _imageNA.SetActive(_collectNA);
                _imageSU.SetActive(_collectSU);
                Collect();
                break;

            case ItemKind.hasu:
                _collectHA = !_collectHA;
                _collectSU = !_collectSU;
                _imageHA.SetActive(_collectHA);
                _imageSU.SetActive(_collectSU);
                Collect();
                break;
        }

    }

    static void Collect()
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
    }

    public static void Verification()
    {
        if (_collectHA && _collectNA && _collectSU)
        {
            ScoreManager.GetScore(_getScoreValue);
            Debug.Log("成功");
            TalkJudgement.Instance._Success = true;
        }
        else
        {
            ScoreManager.GetScore(-10);
            TalkJudgement.Instance._Failure = true;
        }
        ResetCollect();
    }

}
