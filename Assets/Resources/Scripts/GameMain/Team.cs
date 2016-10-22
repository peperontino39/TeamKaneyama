using UnityEngine;
using System.Collections;

public class Team : MonoBehaviour
{

    [SerializeField]
    GameObject select_pieces;
    [SerializeField]
    CreateBoard board;

    private Vector2 moveSell;
    enum Step
    {
        SERECT,
        MOVE,
        ATACK
    }
    Step step = 0;

    void Start()
    {


    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
            {
                GameObject obj = hit.collider.gameObject;
                switch (step)
                {
                    case Step.SERECT:
                        select_pieces = obj.GetComponent<SellDate>().on_pise;
                        if (select_pieces != null)
                        {
                            select_pieces.GetComponent<piece>().OnMoveArea();
                            step++;
                        }
                        break;
                    case Step.MOVE:
                        if (obj.GetComponent<SellDate>().is_movable)
                        {
                            moveSell = obj.GetComponent<SellDate>().sell;
                            select_pieces.GetComponent<piece>().OnAttackArea(moveSell);
                            
                        step++;
                        }
                        else
                        {
                            step = 0;
                        }
                        board.allMovableOff();
                        break;
                    case Step.ATACK:

                        if (obj.GetComponent<SellDate>().is_attack)
                        {
                            board.OnPiceMove(select_pieces.GetComponent<piece>().sell, moveSell);
                            select_pieces.GetComponent<piece>().setSell(moveSell);
                            
                        }
                        board.allAttackOff();
                        step = 0;
                            break;

                }
                
            }
            else
            {
                board.allMovableOff();
                board.allAttackOff();
                step = 0;
            }
        }
    }
}
