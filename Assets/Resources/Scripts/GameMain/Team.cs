using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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
            size = new Vector2(11,3)},
    new Area() {
        pos = new Vector2(0,8),
        size = new Vector2(11,11)}

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
        if (control_team == 1)
        {
            GamaManager.Instance.cameraAndCanvasController.tergetAngle = 180;

        }
        else
        {
            GamaManager.Instance.cameraAndCanvasController.tergetAngle = 0;

        }

        //チームのAreaに敵が2体以上入っていたら城を開ける
        if (GamaManager.Instance.Board.getTeamNum(
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

        ChoiceCell = new Vector2(4, 4);

    }


    int gamepad1_left_axisx;
    int gamepad1_left_axisy;
    int gamepad2_left_axisx;
    int gamepad2_left_axisy;


    private Vector2 choiceCell;


    public Vector2 ChoiceCell
    {
        get { return choiceCell; }
        set
        {

            var piece = GamaManager.Instance.Board.map[(int)choiceCell.y][(int)choiceCell.x].on_pise;
            if (piece != null)
            {
                piece.gameObject.transform.position += new Vector3(0, -0.5f, 0);

            }
            choiceCell = value;
            choiceCell.x = Mathf.Min(Mathf.Max(choiceCell.x, 0), 10);
            choiceCell.y = Mathf.Min(Mathf.Max(choiceCell.y, 0), 10);
            piece = GamaManager.Instance.Board.map[(int)choiceCell.y][(int)choiceCell.x].on_pise;
            setUiStatus(piece);
            if (piece != null)
            {
                piece.gameObject.transform.position += new Vector3(0, 0.5f, 0);
            }

            GamaManager.Instance.SelectObject.transform.position
                = GamaManager.Instance.Board.map[(int)choiceCell.y][(int)choiceCell.x].transform.position +
                new Vector3(0, 0.1f, 0);
            GamaManager.Instance.cameraAndCanvasController.tergetPosition =
            GamaManager.Instance.Board.map[(int)choiceCell.y][(int)choiceCell.x].transform.position;
        }
    }
    void Update()
    {

        if (select_pieces != null)
        {
            select_pieces.gameObject.transform.position += new Vector3(0, Mathf.Sin(Time.time * 30) / 20, 0);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            //ChangeControlTeam();
            StartCoroutine(SceneChange());
        }
        //isPress
        //(int)Input.GetAxisRaw("GamePad1_Left_Axis_x") != 0

        GamePadBegin();

        if (control_team == 0)
        {
            if (gamepad1_left_axisy != 0 || gamepad1_left_axisx != 0)
            {
                ChoiceCell += new Vector2(gamepad1_left_axisx, -gamepad1_left_axisy);
            }
        }
        else
        {
            if (gamepad2_left_axisy != 0 || gamepad2_left_axisx != 0)
            {
                ChoiceCell += new Vector2(-gamepad2_left_axisx, gamepad2_left_axisy);
            }
        }


        if (control_team == 0)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                Atack();
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {

                stepup();
            }
            else if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                Cancel();
            }

            else if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                InCastle();

            }
            else if (Input.GetKeyDown(KeyCode.Joystick1Button3))
            {
                End();
            }
            else if (Input.GetKeyDown(KeyCode.Joystick1Button4))
            {
                ExitCastle();
            }
            else if (Input.GetKeyDown(KeyCode.Joystick1Button5))
            {
                Siege();
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                Atack();

            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                stepup();
            }
            else if (Input.GetKeyDown(KeyCode.Joystick2Button1))
            {
                Cancel();
            }
            else if (Input.GetKeyDown(KeyCode.Joystick2Button2))
            {
                InCastle();

            }
            else if (Input.GetKeyDown(KeyCode.Joystick2Button3))
            {
                End();
            }
            else if (Input.GetKeyDown(KeyCode.Joystick2Button4))
            {
                ExitCastle();
            }
            else if (Input.GetKeyDown(KeyCode.Joystick2Button5))
            {
                Siege();
            }

        }



        gamepad1_left_axisx = (int)Input.GetAxisRaw("GamePad1_Left_Axis_x");
        gamepad1_left_axisy = (int)Input.GetAxisRaw("GamePad1_Left_Axis_y");
        gamepad2_left_axisx = (int)Input.GetAxisRaw("GamePad2_Left_Axis_x");
        gamepad2_left_axisy = (int)Input.GetAxisRaw("GamePad2_Left_Axis_y");




    }

    private static void DebugMouseSertc()
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
    }

    private void GamePadBegin()
    {
        if (gamepad1_left_axisx == (int)Input.GetAxisRaw("GamePad1_Left_Axis_x"))
        {
            gamepad1_left_axisx = 0;
        }
        if (gamepad1_left_axisy == (int)Input.GetAxisRaw("GamePad1_Left_Axis_y"))
        {
            gamepad1_left_axisy = 0;
        }
        if (gamepad2_left_axisx == (int)Input.GetAxisRaw("GamePad2_Left_Axis_x"))
        {
            gamepad2_left_axisx = 0;
        }
        if (gamepad2_left_axisy == (int)Input.GetAxisRaw("GamePad2_Left_Axis_y"))
        {
            gamepad2_left_axisy = 0;
        }
    }

    private void stepup()
    {
        SellDate _sell = GamaManager.Instance.Board.map[(int)choiceCell.y][(int)choiceCell.x];
        switch (step)
        {
            case Step.SERECT:

                if (_sell.on_pise == null) break;

                if (_sell.on_pise.team_number != control_team) break;
                select_pieces = _sell.on_pise;

                //攻撃範囲にてきがいた場合足踏みができる処理
                if (GamaManager.Instance.Board.IsAttackAreanEnemy(select_pieces))
                {
                    GamaManager.Instance.Board.setMovable(select_pieces.sell);
                }
                //選択されたマスが城だったら城から王を出す処理
                if (GamaManager.Instance.castles.isCatles(select_pieces.sell))
                {
                    GamaManager.Instance.command_list.SetInteractable(Command.EXITCASTLE, true);
                    GamaManager.Instance.command_list.SetInteractable(Command.CANCEL, true);

                    setUiStatus(select_pieces);
                    step++;

                    break;

                }
                //包囲している駒でなかったら
                if (!select_pieces.is_siege)
                {
                    setUiStatus(select_pieces);
                    select_pieces.OnMoveArea();
                    step++;
                    GamaManager.Instance.command_list.SetInteractable(Command.CANCEL, true);
                }

                break;
            case Step.MOVE:
                if (_sell.is_movable)
                {

                    moveSell = _sell.sell;
                    step++;
                    if (GamaManager.Instance.castles.isCatles(_sell.sell))
                    {
                        GamaManager.Instance.command_list.SetInteractable(Command.INCASTLE, true);
                        break;
                    }


                    //包囲可能だったら
                    if (GamaManager.Instance.castles.CastleAdjacent(moveSell, select_pieces.team_number))
                    {
                        GamaManager.Instance.command_list.SetInteractable(Command.SIEGE, true);
                    }

                    GamaManager.Instance.command_list.SetInteractable(Command.ATTACK, true);
                    GamaManager.Instance.command_list.SetInteractable(Command.END, true);

                    select_pieces.OnAttackArea(moveSell);
                    GamaManager.Instance.Board.allMovableOff();
                }

                break;
            case Step.ACTIVITY:

                break;

        }
    }

    private bool Gamepadpush()
    {
        return gamepad1_left_axisx == 0 &&
                     (int)Input.GetAxisRaw("GamePad1_Left_Axis_x") == -1;
    }

    //
    public void ChangeControlTeam()
    {
        setControlTeam((control_team + 1) % 2);
        select_pieces.transform.position = new Vector3(select_pieces.transform.position.x, 1.5f, select_pieces.transform.position.z);
        select_pieces = null;
    }


    //攻撃する

    public void Atack()
    {
        if (!GamaManager.Instance.command_list.command_list[(int)Command.ATTACK].IsInteractable())
            return;
        GamaManager.Instance.Board.OnPiceMove(select_pieces.sell, moveSell);
        GamaManager.Instance.Board.AllAttack(select_pieces);
        select_pieces.setSell(moveSell);
        ChangeControlTeam();
        GamaManager.Instance.Board.allAttackOff();
        step = 0;
        GamaManager.Instance.command_list.ALLSetInteractable(false);
        int win_team_num = GamaManager.Instance.kings_info.WinTeam();
        if (win_team_num != -1)
        {
            step = Step.ACTIVITY;
            turn.text = ((win_team_num + 1) + "の勝利");
            StartCoroutine(SceneChange());
        }
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(1.0f);
        GamaManager.Instance.WinWindow.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Title");

    }
    //Turnを切り替えるよ
    private void ChangeTurn()
    {

        GamaManager.Instance.Board.OnPiceMove(select_pieces.sell, moveSell);
        select_pieces.setSell(moveSell);
        ChangeControlTeam();
        GamaManager.Instance.Board.allAttackOff();
        GamaManager.Instance.Board.allMovableOff();

        step = 0;
        GamaManager.Instance.command_list.ALLSetInteractable(false);
    }
    //包囲
    public void Siege()
    {
        if (!GamaManager.Instance.command_list.command_list[(int)Command.SIEGE].IsInteractable())
            return;

        select_pieces.is_siege = true;
        GamaManager.Instance.Board.OnPiceMove(select_pieces.sell, moveSell);
        select_pieces.setSell(moveSell);

        if (GamaManager.Instance.castles.IsWin(select_pieces))
        {
            step = Step.ACTIVITY;
            turn.text = ((control_team + 1) + "の勝利");
            StartCoroutine(SceneChange());
            return;
        }



        GamaManager.Instance.Board.allAttackOff();
        step = 0;
        GamaManager.Instance.command_list.ALLSetInteractable(false);

        ChangeTurn();


    }
    //攻撃せずに移動する
    public void End()
    {
        if (!GamaManager.Instance.command_list.command_list[(int)Command.END].IsInteractable())
            return;

        ChangeTurn();
    }

    //キャンセル
    public void Cancel()
    {
        GamaManager.Instance.Board.allMovableOff();
        GamaManager.Instance.Board.allAttackOff();
        select_pieces = null;
        step = 0;

        GamaManager.Instance.command_list.ALLSetInteractable(false);

    }

    //城にはいる　

    public void InCastle()
    {
        if (!GamaManager.Instance.command_list.command_list[(int)Command.INCASTLE].IsInteractable())
            return;

        ChangeTurn();

    }
    //城からでる
    public void ExitCastle()
    {
        if (!GamaManager.Instance.command_list.command_list[(int)Command.EXITCASTLE].IsInteractable())
            return;

        select_pieces.OnMoveArea();
    }


    //Uiに駒の情報を入れる
    public void setUiStatus(piece _piece)
    {
        if (_piece == null)
        {
            select_status.text = "何もいないよ";
            return;
        }
        string pisename = getPieceName(_piece.piece_num);
        select_status.text =
            "status\n" +
            pisename + "\n" +
            "体力　　" + _piece.life + " / " + _piece.max_hp + "\n" +
            "攻撃力　" + _piece.attack_power + "\n" +
            "反撃力　" + _piece.counter_attack_power + "\n"
            ;
    }

    private static string getPieceName(PieceNum _piece)
    {
        switch (_piece)
        {
            case PieceNum.PAWN:
                return "ポーン";
            case PieceNum.QUEEN:
                return "クイーン";
            case PieceNum.ROOK:
                return "ルーク";
            case PieceNum.JACK:
                return "ジャック";
            case PieceNum.BISOP:
                return "ビショップ";
            case PieceNum.KING:
                return "キング";
            case PieceNum.KNIGHT:
                return "ナイトウ";
        }
        return "";
    }
}
