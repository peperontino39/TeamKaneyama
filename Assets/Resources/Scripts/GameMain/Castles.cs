using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Castles : MonoBehaviour
{

    public List<Castle> castles = new List<Castle>();

    public void SetOpen(int _team_num, bool is_open)
    {
        foreach (var castle in castles)
        {
            if(castle.team_num == _team_num)
            {
                castle.is_open = is_open;
            }

        }
    }

    public GameObject getCatle(int team_num)
    {
       // Debug.Log(castles.Count);
        foreach (var castle in castles)
        {
            if (castle.team_num == team_num)
            {
                return castle.gameObject;
            }

        }
        return null;
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
                    if (_sell == castle.sell + new Vector2(x, y))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool IsWin(piece _piece)
    {
        foreach (var castle in castles)
        {
            if (_piece.team_number != castle.team_num)
            {


                Vector2 rev = castle.sell + (castle.sell - _piece.sell);
                Debug.Log(rev);

                if (GamaManager.Instance.Board.getSellDate(rev).on_pise != null)
                {

                    if (GamaManager.Instance.Board.getSellDate(rev).on_pise.is_siege)
                    {

                        return true;
                    }
                }

                //Vector2 rev = castle.sell-(_piece.sell - castle.sell);
                //if (GamaManager.Instance.Board.getSellDate(rev).)
                return false;

            }
        }
        return false;
    }

    //そのマスに城があったらtrueを返します
    public bool isCatles(Vector2 _sell)
    {
        foreach (var cas in castles)
        {
            if (cas.sell == _sell)
            {
                return true;
            }
        }
        return false;
    }

    public void AddCastle(Castle _castle)
    {
        castles.Add(_castle);
    }

    internal void Add(Castle cas)
    {
        throw new NotImplementedException();
    }
}
