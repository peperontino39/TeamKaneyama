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
    private List<List<SellDate>> map = new List<List<SellDate>>();
    [SerializeField]
    TextAsset csvFile;

    [SerializeField]
    Team team;



    void Start()
    {
        CreateStage();

        
    }

    void Update()
    {


    }

    private void CreateStage()
    {
        StringReader reader = new StringReader(csvFile.text);
        string line = "";

        List<SellDate> cube_line = new List<SellDate>();

        int whidth = 0;
        int height = 0;

        while ((line = reader.ReadLine()) != null)
        {
            whidth = 0;
            string[] fields = line.Split(',');
            foreach (var field in fields)
            {
                if (field == "") continue;

                var cube = Instantiate(selllist[int.Parse(field)]);
                cube.transform.position = new Vector3(whidth, 0, height);
                cube.GetComponent<SellDate>().SetStatus(int.Parse(field));
                cube.GetComponent<SellDate>().sell = new Vector2(whidth, height);
                cube_line.Add(cube.GetComponent<SellDate>());

                whidth++;
            }
            height++;
           
            map.Add(new List<SellDate>(cube_line));
            cube_line.Clear();
        }
       
    }

    public bool setMovable(Vector2 _sell)
    {
        if ((int)_sell.y < 0) return false;
        if ((int)_sell.y >= map.Count) return false;
        if ((int)_sell.x < 0) return false;
        if ((int)_sell.x >= map[(int)_sell.y].Count) return false;

        map[(int)_sell.y][(int)_sell.x].GetComponent<SellDate>().setMovable(true);
        return true;
    }
    public bool setIsAttack(Vector2 _sell)
    {
        if ((int)_sell.y < 0) return false;
        if ((int)_sell.y >= map.Count) return false;
        if ((int)_sell.x < 0) return false;
        if ((int)_sell.x >= map[(int)_sell.y].Count) return false;

        map[(int)_sell.y][(int)_sell.x].GetComponent<SellDate>().SetAttack(true);
        return true;
    }

    public void allMovableOff()
    {

        foreach (var lines in map)
        {
            foreach (var sell in lines)
            {
                sell.GetComponent<SellDate>().setMovable(false);
            }
        }
    }
    public void allAttackOff()
    {

        foreach (var lines in map)
        {
            foreach (var sell in lines)
            {
                sell.GetComponent<SellDate>().is_attack = false;
            }
        }
    }

    public void setOnpise(Vector2 _sell, GameObject piece)
    {
        GameObject picec = map[(int)_sell.y][(int)_sell.x].on_pise = piece;

    }



    public Vector3 getSellPosition(Vector2 _sell)
    {
        
        return map[(int)_sell.y][(int)_sell.x].transform.position
            + Vector3.up;
    }

}
