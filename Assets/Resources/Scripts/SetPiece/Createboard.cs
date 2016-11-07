using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;

public class Createboard : MonoBehaviour
{
    static Createboard instance;
    public static Createboard Instance
    {
        get { return instance; }
    }

    [SerializeField]
    GameObject boardobj;

    List<GameObject> boardList = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }

    public static Createboard GetInstance()
    {
        return instance;
    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject obj = Instantiate(boardobj);
                Vector3 boardPos = new Vector3(i - 4, 1, j - 4);
                obj.transform.position = boardPos;

                boardList.Add(obj);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}