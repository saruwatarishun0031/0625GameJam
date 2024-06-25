using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextChildList
{
    public List<TextList> list = new List<TextList>();

    // デフォルトコンストラクタ
    public TextChildList() { }

    // コンストラクタ
    public TextChildList(List<TextList> _list)
    {
        list = _list;
    }
}
