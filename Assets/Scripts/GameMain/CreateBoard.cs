using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;

public class CreateBoard : MonoBehaviour
{
    [SerializeField]
    public GameObject[] selllist;

    private List<List<GameObject>> map = new List<List<GameObject>>();


    void Start()
    {
        CreateStage();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
            {
                GameObject obj = hit.collider.gameObject;
                obj.GetComponent<SellDate>().setMovable(true);
            }
        }
    }

    private void CreateStage()
    {
        TextAsset csvFile = Resources.Load("Data/Board") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);
        string line = "";

        int height = 0;
        List<GameObject> cube_line = new List<GameObject>();
        while ((line = reader.ReadLine()) != null)
        {
            string[] fields = line.Split(',');
            int whidth = 0;
            foreach (var field in fields)
            {
                if (field == "") continue;

                var cube = Instantiate(selllist[int.Parse(field)]);
                cube.transform.position = new Vector3(whidth, 0, height);
                cube.GetComponent<SellDate>().SetStatus(int.Parse(field));
                cube.GetComponent<SellDate>().sell = new Vector2(whidth, height);

                cube_line.Add(cube);
                whidth++;
            }
            height++;
        }
        map.Add(cube_line);
    }
    public void setMovable(Vector2 _sell)
    {
        map[(int)_sell.y][(int)_sell.x].GetComponent<SellDate>().setMovable(true);
    }

    public void allOff()
    {

        foreach (var lines in map)
        {
            foreach (var sell in lines)
            {
                sell.GetComponent<SellDate>().setMovable(false);
            }
        }

    }

    public void moveSell(Vector2 _before_sell, Vector2 _go_sell)
    {
        //map[(int)_before_sell.y][(int)_before_sell.x].
        //    GetComponent<SellDate>().on_pise = ;

    }

    public Vector3 getSellPosition(Vector2 _sell)
    {
        return map[(int)_sell.y][(int)_sell.x].transform.position 
            + Vector3.up;
    }

}
