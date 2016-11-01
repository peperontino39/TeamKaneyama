using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class ChoicesController : MonoBehaviour {

    [SerializeField]
    GameObject button;

    List<GameObject> buttons = new List<GameObject>();

    [SerializeField]
    public string[] button_names;

    public UnityAction[] butsrc;

    // Use this for initialization
    void Start ()
    {


        butsrc = new UnityAction[button_names.Length];
        butsrc[0] += YesChoice;//+=で関数追加-=で関数削除
        butsrc[1] += NoChoice;

        
        for (int i = 0;i < button_names.Length; i++)
        {
            int renge = 50;
            int uppos = button_names.Length * renge / 2- renge/2;
                CreateButton(new Vector3(0, uppos - renge * i, 0),
                    button_names[i]);
            buttons[i].GetComponent<Button>().onClick.AddListener(butsrc[i]);

        }
        
    }

    private void CreateButton(Vector3 pos,string _text)
    {
        GameObject obj = Instantiate(button);
        obj.transform.position = pos + transform.position;
        obj.transform.root.SetParent(gameObject.transform);
        obj.transform.FindChild("Text").gameObject.GetComponent<Text>().text = _text;
        buttons.Add(obj);
    }

    // Update is called once per frame
    void Update () {

    }

    public void YesChoice()
    {
        Debug.Log("いえーい");
    }



    public  void NoChoice()
    {
        Debug.Log("ああ？");
    }

   

}


