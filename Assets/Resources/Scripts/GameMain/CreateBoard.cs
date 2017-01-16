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
    public List<List<SellDate>> map = new List<List<SellDate>>();
    [SerializeField]
    TextAsset csvFile = null;




    void Awake()
    {
        CreateStage();
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

    //攻撃可能範囲に敵がいたらtrueを返します
    public bool IsAttackAreanEnemy(piece _piece)
    {
        _piece.OnAttackArea(_piece.sell);
        foreach (var line in map)
        {
            foreach (var _sell in line)
            {
                if (_sell.is_attack)
                {
                    if (_sell.on_pise != null)
                    {
                        if (_sell.on_pise.team_number != _piece.team_number)
                        {
                            allAttackOff();
                            return true;
                        }
                    }
                }
            }
        }
        allAttackOff();
        return false;
    }



    //実際に全体攻撃する関数
    //攻撃可能マスに攻撃を与える関数
    //反撃も入っている
    public void AllAttack(piece _terget_piese)
    {
        StartCoroutine(AllAttackCoroutine(_terget_piese));

    }

    private IEnumerator AllAttackCoroutine(piece _terget_piese)
    {
        _terget_piese.anim.StartAnim(2, 3, 3);
        //
        List<piece> anger = new List<piece>();
        //_terget_piese.OnAttackArea(_terget_piese.sell);
        // Debug.Log(_terget_piese);
        foreach (var _line in map)
        {
            foreach (var _sell in _line)
            {
                if (_sell.is_attack)
                {
                    if (_sell.on_pise != null)
                    {
                        if (_terget_piese.
                            team_number !=
                      _sell.on_pise.team_number)
                        {

                            _sell.on_pise.damage(
                                _terget_piese.attack_power, 3);

                            if (_sell.on_pise != null)
                                anger.Add(_sell.on_pise);
                        }
                    }
                }
            }
        }
        allAttackOff();
        GamaManager.Instance.movieDate.damagePiece = new List<piece>(anger);
        GamaManager.Instance.movieDate.movePiece = new List<piece>() { _terget_piese };
        GamaManager.Instance.movieDate.attackPiece = new List<piece>() { _terget_piese };

        List<piece> _counterPiece = new List<piece>();
        foreach (var ang in anger)
        {
            if (ang.life > 0)
            {
                ang.anim.StartAnim(3, 3, 2);
                ang.anim.StartAnim(2, 6, 2);
                
            }
            else
            {
                ang.anim.StartAnim(1, 2.5f, 5);
            }

        }
        //反撃の処理
        bool is_counter = false;
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
                            if (ang.team_number != _sell.on_pise.team_number)
                            {
                                if (_sell.on_pise == _terget_piese)
                                {
                                    if (ang.life > 0)
                                    {
                                        _sell.on_pise.damage(ang.counter_attack_power,6);
                                        _counterPiece.Add(ang);
                                        is_counter = true;
                                    }
                                }
                            }
                        }
                    }

                }

            }

            allAttackOff();
        }
        if (is_counter)
        {
            if (_terget_piese.life > 0)
            {
                _terget_piese.anim.StartAnim(3, 4.5f, 2);
            }
            else
            {
                _terget_piese.anim.StartAnim(1, 4.5f, 2);
            }
        }
       
        GamaManager.Instance.movieDate.counterPiece = new List<piece>(_counterPiece);
        yield return new WaitForSeconds(1.0f);
    }

    //指定した範囲にほかのチームの駒が何体いるのか？
    public int getTeamNum(Vector2 start_sell, Vector2 size, int team_num)
    {
        int num = 0;
        for (int y = (int)start_sell.y; y < size.y; y++)
        {

            for (int x = (int)start_sell.x; x < size.x; x++)
            {
                // Debug.Log(x.ToString() + "  " + y.ToString());
                if (map[y][x].on_pise != null)
                {
                    if (map[y][x].on_pise.team_number != team_num)
                    {
                        num++;
                    }
                }
            }
        }

        return num;
    }

    public void setMovable(Vector2 _sell)
    {
        map[(int)_sell.y][(int)_sell.x].setMovable(true);
    }
    public bool setMovable(Vector2 _sell, int team_num)
    {
        if ((int)_sell.y < 0) return false;
        if ((int)_sell.y >= map.Count) return false;
        if ((int)_sell.x < 0) return false;
        if ((int)_sell.x >= map[(int)_sell.y].Count) return false;
        if (map[(int)_sell.y][(int)_sell.x].on_pise != null)
            return false;
        foreach (var cas in GamaManager.Instance.castles.castles)
        {
            if (_sell == cas.sell)
            {
                if (GamaManager.Instance.team.select_pieces.piece_num == PieceNum.KING)
                {
                    if (cas.team_num == team_num)
                    {
                        if (cas.is_open)
                        {
                            map[(int)_sell.y][(int)_sell.x].setMovable(true);
                            return false;
                        }
                    }
                }
                return false;
            }
        }


        map[(int)_sell.y][(int)_sell.x].setMovable(true);
        return true;
    }
    public bool setIsAttack(Vector2 _sell, int team_num)
    {
        if ((int)_sell.y < 0) return false;
        if ((int)_sell.y >= map.Count) return false;
        if ((int)_sell.x < 0) return false;
        if ((int)_sell.x >= map[(int)_sell.y].Count) return false;
        foreach (var cas in GamaManager.Instance.castles.castles)
        {
            if (_sell == cas.sell) return false;
        }
        if (map[(int)_sell.y][(int)_sell.x].on_pise != null)
        {
            if (map[(int)_sell.y][(int)_sell.x].on_pise.team_number != team_num)
            {
                map[(int)_sell.y][(int)_sell.x].SetAttack(true);
            }
            if (_sell == GamaManager.Instance.team.select_pieces.sell)
            {
                map[(int)_sell.y][(int)_sell.x].SetAttack(true);
                return true;
            }
            return false;
        }

        map[(int)_sell.y][(int)_sell.x].SetAttack(true);
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

    public void setOnpise(Vector2 _sell, piece _piece)
    {
        map[(int)_sell.y][(int)_sell.x].on_pise = _piece;

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
        if (_terget == go_selll) return;
        map[(int)_terget.y][(int)_terget.x].on_pise = null;
    }

    public SellDate getSellDate(int x, int y)
    {
        return map[x][y];
    }
    public SellDate getSellDate(Vector2 _sell)
    {
        return map[(int)_sell.x][(int)_sell.y];
    }



}
