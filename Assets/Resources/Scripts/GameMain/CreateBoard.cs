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

    public List<Castle> castles = new List<Castle>();

    void Awake()
    {
        CreateStage();
    }

    void Start()
    {


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

    public void AllAttack(GameObject _terget_piese)
    {
        List<piece> anger = new List<piece>();
        foreach (var _line in map)
        {
            foreach (var _sell in _line)
            {
                if (_sell.is_attack)
                {
                    if (_sell.on_pise != null)
                    {


                        if (_terget_piese.GetComponent<piece>().
                            team_number !=
                      _sell.on_pise.GetComponent<piece>().team_number)
                        {
                            _sell.on_pise.GetComponent<piece>().damage(
                                _terget_piese.GetComponent<piece>().attack_power);

                            anger.Add(_sell.on_pise.GetComponent<piece>());
                        }
                    }
                }
            }
        }
        allAttackOff();
        //反撃の処理
        foreach (var ang in anger)
        {
            ang.OnAttackArea(ang.sell);
            foreach (var _line in map)
            {
                foreach (var _sell in _line)
                {
                    if (_sell.is_attack)
                    {
                        if (_sell.on_pise != null)
                        {
                            if (ang.team_number !=
                      _sell.on_pise.GetComponent<piece>().team_number)
                            {

                                _sell.on_pise.GetComponent<piece>().damage(ang.counter_attack_power);

                            }
                        }
                    }

                }

            }
            allAttackOff();
        }
    }

    public bool CastleAdjacent(Vector2 _sell, int _team_num)
    {
        foreach (var castle in castles)
        {
            if (_team_num == castle.team_num)
                continue;
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if(_sell == castle.sell + new Vector2(x, y))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }


    public void AddCastle(Castle _castle)
    {
        castles.Add(_castle);



    }
    public bool setMovable(Vector2 _sell)
    {
        if ((int)_sell.y < 0) return false;
        if ((int)_sell.y >= map.Count) return false;
        if ((int)_sell.x < 0) return false;
        if ((int)_sell.x >= map[(int)_sell.y].Count) return false;
        if (map[(int)_sell.y][(int)_sell.x].GetComponent<SellDate>().on_pise != null)
            return false;

        map[(int)_sell.y][(int)_sell.x].GetComponent<SellDate>().setMovable(true);
        return true;
    }
    public bool setIsAttack(Vector2 _sell)
    {
        if ((int)_sell.y < 0) return false;
        if ((int)_sell.y >= map.Count) return false;
        if ((int)_sell.x < 0) return false;
        if ((int)_sell.x >= map[(int)_sell.y].Count) return false;
        if (map[(int)_sell.y][(int)_sell.x].GetComponent<SellDate>().on_pise != null)
        {
            map[(int)_sell.y][(int)_sell.x].GetComponent<SellDate>().SetAttack(true);
            return false;
        }
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
                sell.GetComponent<SellDate>().SetAttack(false);
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

    public void OnPiceMove(Vector2 _terget, Vector2 go_selll)
    {
        map[(int)go_selll.y][(int)go_selll.x].on_pise =
        map[(int)_terget.y][(int)_terget.x].on_pise;
        map[(int)_terget.y][(int)_terget.x].on_pise = null;
    }

}
