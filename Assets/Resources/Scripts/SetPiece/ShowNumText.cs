using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowNumText : MonoBehaviour {

    /*static ShowNumText instance;
    public static ShowNumText Instance
    {
        get { return instance; }
    }*/

    [SerializeField]
    int PieceNum;

    [SerializeField]
    Text PieceNumText;

    //void Awake()
    //{
    //    instance = this;
    //}

    // Use this for initialization
    void Start () {
        PieceNumText.text = "×" + PieceNum.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
