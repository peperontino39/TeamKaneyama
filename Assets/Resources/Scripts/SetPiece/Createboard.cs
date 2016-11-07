using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Createboard : MonoBehaviour {

    static Createboard instance;
    public static Createboard Instance
    {
        get { return instance; }
    }

    [SerializeField]
    GameObject boardobj;

    List<GameObject> boardObjList = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }

    public static Createboard GetInstance()
    {
        return instance;
    }

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject obj = Instantiate(boardobj);
                Vector3 pinPos = new Vector3(j - 4.5f, 1, i);
                obj.transform.position = pinPos;

                boardObjList.Add(obj);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
