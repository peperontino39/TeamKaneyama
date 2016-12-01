using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;



public class log : MonoBehaviour
{
    [SerializeField]
    Text text;
    int maxlog = 3;

    public List<string> logTexts;

    void Start()
    {
        text.text = "";

        addText("hbjhuyg");
        addText("hbjhuyg");
        addText("hbjhuyg");
        addText("hbjhuyg");
        addText("hbjhuyg");
        addText("hbjhuyg");

    }


    void addText(string _text)
    {
        logTexts.Add(_text);
        if(logTexts.Count > maxlog)
        {
            logTexts.RemoveAt(maxlog);
        }
        string rizarut = "";
        foreach (var ch in logTexts)
        {
            rizarut += ch;
            rizarut += "\n";
        }
        Debug.Log(rizarut);
        text.text = rizarut;

    }

}
