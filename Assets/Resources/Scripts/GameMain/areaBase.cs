using UnityEngine;
using System.Collections;

public class areaBase
{
    protected Vector2 go_sell;

    public virtual void setMoveOn(piece _piece, CreateBoard board)
    {

    }
    public virtual void SetAttackOn(Vector2 _sell, CreateBoard board)
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
    public override void setMoveOn(piece _piece, CreateBoard board)
    {
        for (int i = 1; i <= length; i++)
        {
            if (!board.setMovable(_piece.sell + (go_sell * i)))
            {
                break;
            }
        }
    }
    public override void SetAttackOn(Vector2 _sell, CreateBoard board)
    {
        
        for (int i = 1; i <= length; i++)
        {
            if (!board.setIsAttack(_sell + (go_sell * i)))
            {
                break;
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
    public override void setMoveOn(piece _piece, CreateBoard board)
    {
        Vector2 onsell = _piece.sell + go_sell;
        board.setMovable(onsell);
    }
    public override void SetAttackOn(Vector2 _sell, CreateBoard board)
    {
        Vector2 onsell = _sell + go_sell;
        board.setIsAttack(onsell);
    }
}



