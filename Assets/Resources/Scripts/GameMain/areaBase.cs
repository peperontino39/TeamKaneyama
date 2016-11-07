using UnityEngine;
using System.Collections;

public class areaBase
{
    protected Vector2 go_sell;

    public virtual void setMoveOn(piece _piece)
    {

    }
    public virtual void SetAttackOn(piece _piece,Vector2 _sell)
    {

    }
}

public class LineArea : areaBase
{
    public LineArea(Vector2 _go_sell, int _length)
    {
        go_sell = _go_sell;
        length = _length;
    }
    int length;
    public override void setMoveOn(piece _piece)
    {
        for (int i = 1; i <= length; i++)
        {
            if (!GamaManager.Instance.Board.setMovable(
                _piece.sell + (go_sell * i),
                _piece.team_number))
            {
                return;
            }
        }
    }
    public override void SetAttackOn(piece _piece,Vector2 _sell)
    {
        
        for (int i = 1; i <= length; i++)
        {
            if (!GamaManager.Instance.Board.setIsAttack(_sell + (go_sell * i),
                _piece.team_number))
            {
                return;
            }
        }
    }

}

public class PointArea : areaBase
{

    public PointArea(Vector2 _go_sell)
    {
        go_sell = _go_sell;
    }
    public override void setMoveOn(piece _piece)
    {
        Vector2 onsell = _piece.sell + go_sell;
        GamaManager.Instance.Board.setMovable(onsell, _piece.team_number);
    }
    public override void SetAttackOn(piece _piece, Vector2 _sell)
    {
        Vector2 onsell = _sell + go_sell;
        GamaManager.Instance.Board.setIsAttack(onsell, _piece.team_number);
    }
}



