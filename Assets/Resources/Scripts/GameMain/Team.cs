using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Team : MonoBehaviour
{

    [SerializeField]
    piece select_pieces = null;
    [SerializeField]
    Text select_status = null;
    [SerializeField]
    Text turn = null;

    Step step = 0;

    private int control_team;
    private Vector2 moveSell;
    // public SellDate select_sell;


    public void setControlTeam(int _num)
    {
        control_team = _num;
        turn.text = "現在はチーム" + (control_team + 1) + "です";
    }



    enum Step
    {
        SERECT,
        MOVE,
        ACTIVITY
    }


    void Start()
    {
        setControlTeam(0);

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
            {
                Debug.Log(hit.collider.gameObject.GetComponent<SellDate>().on_pise);
                

            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
            {
                SellDate _sell = hit.collider.gameObject.GetComponent<SellDate>();
                switch (step)
                {
                    case Step.SERECT:
                        select_pieces = _sell.on_pise;
                        if (select_pieces != null)
                        {
                            if (select_pieces.team_number == control_team)
                            {
                                if (!select_pieces.is_siege)
                                {
                                    setUiStatus(select_pieces);
                                    select_pieces.OnMoveArea();
                                    step++;
                                    GamaManager.Instance.command_list.SetInteractable(CommandList.Command.CANCEL, true);
                                }
                            }
                        }
                        break;
                    case Step.MOVE:
                        if (_sell.is_movable)
                        {
                            moveSell = _sell.sell;
                            if (GamaManager.Instance.castles.CastleAdjacent(moveSell, select_pieces.team_number))
                            {
                                GamaManager.Instance.command_list.SetInteractable(CommandList.Command.SIEGE, true);
                            }

                            select_pieces.OnAttackArea(moveSell);
                            GamaManager.Instance.command_list.SetInteractable(CommandList.Command.ATTACK, true);
                            GamaManager.Instance.command_list.SetInteractable(CommandList.Command.END, true);

                            step++;
                        }

                        //GamaManager.Instance.Board.allMovableOff();
                        break;
                    case Step.ACTIVITY:

                        break;

                }

            }

        }



    }



    public void Atack()
    {
        GamaManager.Instance.Board.AllAttack(select_pieces);
        ChangeTurn();
    }

    private void ChangeTurn()
    {
        GamaManager.Instance.Board.OnPiceMove(select_pieces.sell, moveSell);
        select_pieces.setSell(moveSell);
        setControlTeam((control_team + 1) % 2);
        GamaManager.Instance.Board.allAttackOff();
        step = 0;
        GamaManager.Instance.command_list.ALLSetInteractable(false);
    }

    public void Siege()
    {
        select_pieces.is_siege = true;

        GamaManager.Instance.Board.OnPiceMove(select_pieces.sell, moveSell);
        select_pieces.setSell(moveSell);

        if (GamaManager.Instance.castles.IsWin(select_pieces))
        {
            //Debug.Log((control_team+1) + "の勝利");
            turn.text = ((control_team + 1) %2) + "の勝利";
            return;
        }

        setControlTeam((control_team + 1) % 2);
        GamaManager.Instance.Board.allAttackOff();
        step = 0;
        GamaManager.Instance.command_list.ALLSetInteractable(false);
    }

    public void End()
    {
        GamaManager.Instance.Board.OnPiceMove(select_pieces.GetComponent<piece>().sell, moveSell);
        ChangeTurn();
    }

    public void Cancel()
    {
        GamaManager.Instance.Board.allMovableOff();
        GamaManager.Instance.Board.allAttackOff();
        select_pieces = null;
        step = 0;
        GamaManager.Instance.command_list.SetInteractable(CommandList.Command.CANCEL, false);
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
