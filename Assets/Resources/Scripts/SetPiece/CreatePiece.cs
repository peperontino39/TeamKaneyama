using UnityEngine;
using System.Collections;

public class CreatePiece : MonoBehaviour {

    [SerializeField]
    GameObject[] pieces;

    // Use this for initialization
    void Start () {
        CreatePieces(PieceNum.PAWN, -6.0f, -2.0f);
        CreatePieces(PieceNum.ROOK, -2.5f, -2.0f);
        CreatePieces(PieceNum.BISOP, 1.0f, -2.0f);
        CreatePieces(PieceNum.KNIGHT, 4.5f, -2.0f);
        CreatePieces(PieceNum.QUEEN, -4.0f, -4.0f);
        CreatePieces(PieceNum.KING, -0.5f, -4.0f);
        CreatePieces(PieceNum.JACK, 3.0f, -4.0f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreatePieces(PieceNum _piece, float x, float z)
    {
        GameObject obj = Instantiate(pieces[(int)_piece]);
        Vector3 piecePos = new Vector3(x, 1, z);
        obj.transform.position = piecePos;
    }
}
