using UnityEngine;
using System.Collections.Generic;

public class Createboard : MonoBehaviour
{

    static Createboard instance;
    public static Createboard Instance
    {
        get { return instance; }
    }

    [SerializeField]
    GameObject boardobj;

    List<List<SaveInfomation>> boardObjList = new List<List<SaveInfomation>>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    public static Createboard GetInstance()
    {
        return instance;
    }

    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < 3; i++)
        {
            List<SaveInfomation> line = new List<SaveInfomation>();
            for (int j = 0; j < 9; j++)
            {
                GameObject obj = Instantiate(boardobj);
                //Vector3 pinPos = 
                obj.transform.position = new Vector3(j * 1.5f, i * 1.5f, 5);
                SaveInfomation _sell_date = obj.GetComponent<SaveInfomation>();
                _sell_date.sellnum = new Vector2(j, i);
                boardObjList.Add(new List<SaveInfomation>(line));
            }
            line.Clear();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
