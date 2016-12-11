using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;



public class Log : MonoBehaviour
{
    [SerializeField]
    Text text;
    int maxlog = 3;

    public List<string> logTexts;

    void Start()
    {
        text.text = "";
        
    }


    void addText(string _text)
    {
        logTexts.Add(_text);
        if(logTexts.Count > maxlog)
        {
            logTexts.RemoveAt(0);
        }
        string rizarut = "";
        foreach (var ch in logTexts)
        {
            rizarut += ch;
            rizarut += "\n";
        }
        text.text = rizarut;

    }

}
