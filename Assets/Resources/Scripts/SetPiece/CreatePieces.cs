using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreatePieces : MonoBehaviour
{

    [SerializeField]
    GameObject[] pieces;

    [SerializeField]
    int[] PieceNum;

    [SerializeField]
    Text[] text;

    GameObject select_piece = null;
    // Use this for initialization
    void Start()
    {
        /*CreatePieces(PieceNum.PAWN, -0.5f, -2.0f);
        CreatePieces(PieceNum.ROOK, 3.0f, -2.0f);
        CreatePieces(PieceNum.BISOP, 6.5f, -2.0f);
        CreatePieces(PieceNum.KNIGHT, 10.0f, -2.0f);
        CreatePieces(PieceNum.QUEEN, 1.0f, -4.0f);
        CreatePieces(PieceNum.KING, 4.5f, -4.0f);
        CreatePieces(PieceNum.JACK, 8.0f, -4.0f);*/
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();


        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 9))
            {
                select_piece = Instantiate(hit.collider.gameObject);
            }
        }
        if (select_piece)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 pos = Input.mousePosition;
                pos.z = 0.8f;
                select_piece.transform.position = Camera.main.ScreenToWorldPoint(pos);
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
                {
                    SaveInfomation buff = hit.collider.gameObject.GetComponent<SaveInfomation>();
                    if (buff.piece == null)
                    {
                        buff.piece = select_piece;
                        select_piece.transform.position = hit.collider.gameObject.transform.position + new Vector3(0, 0, -0.1f);
                        select_piece.layer = LayerMask.NameToLayer("Default");
                        //hit.collider.gameObject.GetComponent<SellDate>().on_pise = select_piece;
                    }
                    else
                    {
                        Destroy(select_piece);
                    }
                }
                else
                {
                    Destroy(select_piece);
                }
                select_piece = null;
            }
        }

    }

    /*public void CreatePieces(PieceNum _piece, float x, float y)
    {
        GameObject obj = Instantiate(pieces[(int)_piece]);
        Vector3 piecePos = new Vector3(x, y, 4.9f);
        obj.transform.position = piecePos;
    }*/
}