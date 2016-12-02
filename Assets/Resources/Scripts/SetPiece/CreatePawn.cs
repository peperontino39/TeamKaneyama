using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreatePawn : MonoBehaviour
{

    [SerializeField]
    GameObject pownPieces;

    [SerializeField]
    int pownPieceNum;

    [SerializeField]
    Text powntext;

    GameObject select_piece = null;
    // Use this for initialization
    void Start()
    {
        CreatePieces(0.5f, -2.0f);
        powntext.text = "×" + pownPieceNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (pownPieceNum != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 9))
                {
                    if(hit.collider.gameObject.name == "Setpawn(Clone)")
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
                            pownPieceNum -= 1;
                            powntext.text = "×" + pownPieceNum.ToString();
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
    }

    public void CreatePieces(float x, float y)
    {
        GameObject obj = Instantiate(pownPieces);
        Vector3 piecePos = new Vector3(x, y, 4.9f);
        obj.transform.position = piecePos;
    }
}