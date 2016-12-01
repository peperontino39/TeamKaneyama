using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public struct Area
{
    public Vector2 pos;
    public Vector2 size;

}

public class Team : MonoBehaviour
{
    public List<Area> teamArea = new List<Area>
    {
        new Area() {
            pos = new Vector2(0,0),
            size = new Vector2(9,3)},
    new Area() {
        pos = new Vector2(0,6),
        size = new Vector2(9,9)}

    };



    [SerializeField]
    public piece select_pieces = null;
    [SerializeField]
    Text select_status = null;
    [SerializeField]
    Text turn = null;

    Step step = 0;

    private int control_team;
    private Vector2 moveSell;


    public void setControlTeam(int _num)
    {
        control_team = _num;
        turn.text = "現在はチーム" + (control_team + 1) + "です";

        //Debug.Log(GamaManager.Instance.Board.getTeamNum(
        //        teamArea[control_team].pos,
        //    teamArea[control_team].size,
        //    control_team));
        
        if (
            GamaManager.Instance.Board.getTeamNum(
                teamArea[control_team].pos,
            teamArea[control_team].size,
            control_team) >= 2)
        {
            GamaManager.Instance.castles.SetOpen(control_team, true);
        }
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
                                //攻撃範囲にてきがいた場合足踏みができる処理
                                if (GamaManager.Instance.Board.IsAttackAreanEnemy(select_pieces))
                                {
                                    GamaManager.Instance.Board.setMovable(select_pieces.sell);
                                }
                                //選択されたマスが城だったら
                                if (GamaManager.Instance.castles.isCatles(select_pieces.sell))
                                {
                                    GamaManager.Instance.command_list.SetInteractable(CommandList.Command.EXITCASTLE, true);
                                    GamaManager.Instance.command_list.SetInteractable(CommandList.Command.CANCEL, true);

                                    setUiStatus(select_pieces);
                                    step++;

                                    break;

                                }
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

                            if (GamaManager.Instance.castles.isCatles(_sell.sell))
                            {
                                GamaManager.Instance.command_list.SetInteractable(CommandList.Command.INCASTLE, true);
                                step++;
                                moveSell = _sell.sell;
                                break;
                            }


                            moveSell = _sell.sell;
                            //包囲可能だったら
                            if (GamaManager.Instance.castles.CastleAdjacent(moveSell, select_pieces.team_number))
                            {
                                GamaManager.Instance.command_list.SetInteractable(CommandList.Command.SIEGE, true);
                            }

                            select_pieces.OnAttackArea(moveSell);
                            GamaManager.Instance.command_list.SetInteractable(CommandList.Command.ATTACK, true);
                            GamaManager.Instance.command_list.SetInteractable(CommandList.Command.END, true);

                            step++;
                            GamaManager.Instance.Board.allMovableOff();
                        }

                        break;
                    case Step.ACTIVITY:

                        break;

                }

            }

        }



    }



    public void Atack()
    {
        GamaManager.Instance.Board.OnPiceMove(select_pieces.sell, moveSell);
        GamaManager.Instance.Board.AllAttack(select_pieces);
        select_pieces.setSell(moveSell);
        setControlTeam((control_team + 1) % 2);
        GamaManager.Instance.Board.allAttackOff();
        step = 0;
        GamaManager.Instance.command_list.ALLSetInteractable(false);
        int win_team_num = GamaManager.Instance.kings_info.WinTeam();
        if (win_team_num != -1)
        {
            step = Step.ACTIVITY;
            turn.text = (win_team_num + "の勝利");
        }
    }

    private void ChangeTurn()
    {
        GamaManager.Instance.Board.OnPiceMove(select_pieces.sell, moveSell);
        select_pieces.setSell(moveSell);
        setControlTeam((control_team + 1) % 2);
        GamaManager.Instance.Board.allAttackOff();
        GamaManager.Instance.Board.allMovableOff();

        step = 0;
        GamaManager.Instance.command_list.ALLSetInteractable(false);
    }
    //包囲
    public void Siege()
    {
        select_pieces.is_siege = true;


        GamaManager.Instance.Board.OnPiceMove(select_pieces.sell, moveSell);
        select_pieces.setSell(moveSell);

        if (GamaManager.Instance.castles.IsWin(select_pieces))
        {
            step = Step.ACTIVITY;
            turn.text = ((control_team + 1) % 2) + "の勝利";
            return;
        }



        GamaManager.Instance.Board.allAttackOff();
        step = 0;
        GamaManager.Instance.command_list.ALLSetInteractable(false);

        ChangeTurn();


    }

    public void End()
    {
        ChangeTurn();
    }

    public void Cancel()
    {
        GamaManager.Instance.Board.allMovableOff();
        GamaManager.Instance.Board.allAttackOff();
        select_pieces = null;
        step = 0;

        GamaManager.Instance.command_list.ALLSetInteractable(false);

    }
    public void InCastle()
    {
        ChangeTurn();

    }

    public void ExitCastle()
    {
        select_pieces.OnMoveArea();
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
