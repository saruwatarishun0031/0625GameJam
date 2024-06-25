using UnityEngine;


[System.Serializable]
public class TextList
{
    public string text;
    public int value;


    public TextList(string name, int value)
    {
        this.text = name;
        this.value = value;
    }
}
