using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Team : MonoBehaviour
{

    [SerializeField]
    GameObject select_pieces;
    [SerializeField]
    CreateBoard board;
    [SerializeField]
    Text select_status;
    [SerializeField]
    Text turn;


    private int control_team;
    public void setControlTeam(int _num)
    {
        control_team = _num;
        turn.text = "現在はチーム" + (control_team + 1) + "です";
    }
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
        setControlTeam(0);

    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
            {
                GameObject obj = hit.collider.gameObject;
                switch (step)
                {
                    case Step.SERECT:
                        select_pieces = obj.GetComponent<SellDate>().on_pise;
                        if (select_pieces != null)
                        {
                            if (select_pieces.GetComponent<piece>().team_number == control_team)
                            {
                                setUiStatus(select_pieces.GetComponent<piece>());
                                select_pieces.GetComponent<piece>().OnMoveArea();
                                step++;
                            }
                        }
                        break;
                    case Step.MOVE:
                        if (obj.GetComponent<SellDate>().is_movable)
                        {
                            moveSell = obj.GetComponent<SellDate>().sell;
                            if (board.CastleAdjacent(moveSell, select_pieces.GetComponent<piece>().team_number))
                            {
                                Debug.Log("hoggeogej");
                            }
                            else {
                                select_pieces.GetComponent<piece>().OnAttackArea(moveSell);

                            }
                            step++;
                        }
                        else
                        {
                            step = 0;
                        }
                        board.allMovableOff();
                        break;
                    case Step.ATACK:

                        Atack(obj);
                        break;

                }

            }
            else
            {
                board.allMovableOff();
                board.allAttackOff();
                select_pieces = null;
                step = 0;
            }
        }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
        {
            GameObject obj = hit.collider.gameObject;
            //obj.GetComponent<>

        }

    }

    private void Atack(GameObject obj)
    {
        if (obj.GetComponent<SellDate>().is_attack)
        {
            //if (obj.GetComponent<SellDate>().on_pise != null)
            //{
            //    //違うチームだったら
            //    if (obj.GetComponent<SellDate>().on_pise.GetComponent<piece>().team_number !=
            //        select_pieces.GetComponent<piece>().team_number)
            //        obj.GetComponent<SellDate>().on_pise.GetComponent<piece>().damage(
            //            select_pieces.GetComponent<piece>().attack_power
            //            );
            //}

            board.AllAttack(select_pieces);
            board.OnPiceMove(select_pieces.GetComponent<piece>().sell, moveSell);
            select_pieces.GetComponent<piece>().setSell(moveSell);
            setControlTeam((control_team + 1) % 2);

        }
        if (obj.GetComponent<SellDate>().sell == moveSell)
        {
            board.OnPiceMove(select_pieces.GetComponent<piece>().sell, moveSell);
            select_pieces.GetComponent<piece>().setSell(moveSell);
            setControlTeam((control_team + 1) % 2);

        }
        board.allAttackOff();
        step = 0;
    }

    public void setUiStatus(piece _piece)
    {
        select_status.text =
            "status\n" +
            "体力　　" + _piece.life + " / " + _piece.max_hp + "\n" +
            "攻撃力　" + _piece.attack_power + "\n" +
            "反撃力　" + _piece.counter_attack_power + "\n"
            ;
    }
}
