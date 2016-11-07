using UnityEngine;
using System.Collections;

public enum PieceNum
{
    PAWN,
    ROOK,
    BISOP,
    KNIGHT,
    QUEEN,
    KING,
    JACK
}


public class PicecDeploy : MonoBehaviour
{

    [SerializeField]
    GameObject[] pieces;

    [SerializeField]
    GameObject castle;
   


    void Start()
    {
        CreatePiece(PieceNum.PAWN, 0, 2, 0);
        CreatePiece(PieceNum.PAWN, 1, 2, 0);
        CreatePiece(PieceNum.PAWN, 2, 2, 0);
        CreatePiece(PieceNum.PAWN, 3, 2, 0);
        CreatePiece(PieceNum.PAWN, 4, 2, 0);
        CreatePiece(PieceNum.PAWN, 5, 2, 0);
        CreatePiece(PieceNum.PAWN, 6, 2, 0);
        CreatePiece(PieceNum.PAWN, 7, 2, 0);
        CreatePiece(PieceNum.PAWN, 8, 2, 0);

        CreatePiece(PieceNum.ROOK, 0, 0, 0);
        CreatePiece(PieceNum.ROOK, 8, 0, 0);
        CreatePiece(PieceNum.KNIGHT, 1, 0, 0);
        CreatePiece(PieceNum.KNIGHT, 7, 0, 0);
        CreatePiece(PieceNum.BISOP, 2, 0, 0);
        CreatePiece(PieceNum.BISOP, 6, 0, 0);
        CreatePiece(PieceNum.QUEEN, 3, 0, 0);
        CreatePiece(PieceNum.KING, 4, 0, 0);//
        CreatePiece(PieceNum.JACK, 5, 0, 0);

        CreatePiece(PieceNum.PAWN, 0, 6, 1);
        CreatePiece(PieceNum.PAWN, 1, 6, 1);
        CreatePiece(PieceNum.PAWN, 2, 6, 1);
        CreatePiece(PieceNum.PAWN, 3, 6, 1);
        CreatePiece(PieceNum.PAWN, 4, 6, 1);
        CreatePiece(PieceNum.PAWN, 5, 6, 1);
        CreatePiece(PieceNum.PAWN, 6, 6, 1);
        CreatePiece(PieceNum.PAWN, 7, 6, 1);
        CreatePiece(PieceNum.PAWN, 8, 6, 1);

        CreatePiece(PieceNum.ROOK, 0, 8, 1);
        CreatePiece(PieceNum.ROOK, 8, 8, 1);
        CreatePiece(PieceNum.KNIGHT, 1, 8, 1);
        CreatePiece(PieceNum.KNIGHT, 7, 8, 1);
        CreatePiece(PieceNum.BISOP, 2, 8, 1);
        CreatePiece(PieceNum.BISOP, 6, 8, 1);
        CreatePiece(PieceNum.QUEEN, 3, 8, 1);
        CreatePiece(PieceNum.KING, 4, 8, 1);//
        CreatePiece(PieceNum.JACK, 5, 8, 1);

        CreateCastle(4, 1, 0);
        CreateCastle(4, 7, 1);

    }

    void Update()
    {

    }

    public void CreateCastle(int x, int y, int _team)
    {
        GameObject obj = Instantiate(castle);
        Castle cas = obj.GetComponent<Castle>();
        cas.SetSell(new Vector2(x, y));
        cas.setTeam(_team);
    }


    public void CreatePiece(PieceNum _piece, int x, int y, int _team)
    {

        GameObject obj = Instantiate(pieces[(int)_piece]);
        piece pic = obj.GetComponent<piece>();
        pic.setSell(new Vector2(x, y));
        pic.team_number = _team;
        pic.piece_num = _piece;
        if (_team == 1)
        {
            obj.GetComponent<Renderer>().material.color = new Color(0, 1, 0);
        }
        if(PieceNum.KING == _piece)
        {
            GamaManager.Instance.kings_info.kings.Add(pic);
        }
    }


}
