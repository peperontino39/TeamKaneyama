using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MoveDate{

    //移動した駒
    public List<piece> movePiece;
    //攻撃したピース（大体1体だがlistにしておく）
    public List<piece> attackPiece;
    //ダメージを食らうピースの情報
    public List<piece> damagePiece;
    //反撃をするピースの情報
    public List<piece> counterPiece;
    

}
