using UnityEngine;
using System.Collections;

public class CreatePiece : MonoBehaviour {

    [SerializeField]
    GameObject[] pieces;

    // Use this for initialization
    void Start () {
        CreatePieces(PieceNum.PAWN, -2.0f, -2.0f);
        CreatePieces(PieceNum.ROOK, 1.5f, -2.0f);
        CreatePieces(PieceNum.BISOP, 5.0f, -2.0f);
        CreatePieces(PieceNum.KNIGHT, 8.5f, -2.0f);
        CreatePieces(PieceNum.QUEEN, 0.0f, -4.0f);
        CreatePieces(PieceNum.KING, 3.5f, -4.0f);
        CreatePieces(PieceNum.JACK, 7.0f, -4.0f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreatePieces(PieceNum _piece, float x, float y)
    {
        GameObject obj = Instantiate(pieces[(int)_piece]);
        Vector3 piecePos = new Vector3(x, y, 12);
        obj.transform.position = piecePos;
    }
}
