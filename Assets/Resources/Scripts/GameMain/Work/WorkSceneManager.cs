using UnityEngine;
using System.Collections;

public class WorkSceneManager : MonoBehaviour {

    [SerializeField]
    GameObject pawn;
    [SerializeField]
    GameObject rook;
    [SerializeField]
    GameObject bishop;
    [SerializeField]
    GameObject knight;
    [SerializeField]
    GameObject queen;
    [SerializeField]
    GameObject king;
    [SerializeField]
    GameObject jack;
 
	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
	


	}

    void WorkPieceCoicer()
    {

        switch (GamaManager.Instance.movieDate.movePiece[0].piece_num)
        {
            case PieceNum.PAWN:

                pawn.SetActive(true);
                rook.SetActive(false);
                bishop.SetActive(false);
                knight.SetActive(false);
                queen.SetActive(false);
                king.SetActive(false);
                jack.SetActive(false);

                break;

            case PieceNum.ROOK:

                pawn.SetActive(false);
                rook.SetActive(true);
                bishop.SetActive(false);
                knight.SetActive(false);
                queen.SetActive(false);
                king.SetActive(false);
                jack.SetActive(false);

                break;

            case PieceNum.BISOP:

                pawn.SetActive(false);
                rook.SetActive(false);
                bishop.SetActive(true);
                knight.SetActive(false);
                queen.SetActive(false);
                king.SetActive(false);
                jack.SetActive(false);

                break;

            case PieceNum.KNIGHT:

                pawn.SetActive(false);
                rook.SetActive(false);
                bishop.SetActive(false);
                knight.SetActive(true);
                queen.SetActive(false);
                king.SetActive(false);
                jack.SetActive(false);

                break;

            case PieceNum.QUEEN:

                pawn.SetActive(false);
                rook.SetActive(false);
                bishop.SetActive(false);
                knight.SetActive(false);
                queen.SetActive(true);
                king.SetActive(false);
                jack.SetActive(false);

                break;

            case PieceNum.KING:

                pawn.SetActive(false);
                rook.SetActive(false);
                bishop.SetActive(false);
                knight.SetActive(false);
                queen.SetActive(false);
                king.SetActive(true);
                jack.SetActive(false);

                break;

            case PieceNum.JACK:

                pawn.SetActive(false);
                rook.SetActive(false);
                bishop.SetActive(false);
                knight.SetActive(false);
                queen.SetActive(false);
                king.SetActive(false);
                jack.SetActive(true);

                break;
        }

    }
}
