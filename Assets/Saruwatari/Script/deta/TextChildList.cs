using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextChildList
{
    public List<TextList> list = new List<TextList>();

    // �f�t�H���g�R���X�g���N�^
    public TextChildList() { }

    // �R���X�g���N�^
    public TextChildList(List<TextList> _list)
    {
        list = _list;
    }
}
