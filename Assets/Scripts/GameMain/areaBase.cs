using UnityEngine;
using System.Collections;

public class areaBase
{
    protected Vector2 go_sell;

    public virtual void setMoveOn(Vector2 _sell, CreateBoard board)
    {

    }
}

public class lineArea : areaBase
{
    int length;
    public override void setMoveOn(Vector2 _sell, CreateBoard board)
    {

    }
    
}

public class PointArea : areaBase
{

    public override void setMoveOn(Vector2 _sell, CreateBoard board)
    {
        Vector2 onsell = _sell + go_sell;
        board.setMovable(onsell);
    }
    
}



