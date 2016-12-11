using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class BattleSceneManager : MonoBehaviour
{


    [SerializeField]
    GameObject attacker;
    [SerializeField]
    GameObject[] damager;
    [SerializeField]
    GameObject[] counter;

    public Text attackerNameText;
    public Text damagerNameText;
    public Text counterNameText;

    public Slider attackerHP;
    public Slider damagerHP;
    public Slider counterHP;

    string attackerName;
    string damagerName;
    string counterName;

    Vector3 attackerPos;
    Vector3 damegerPos;
    Quaternion damegerRotate;
    Quaternion attackerRotate;


    // Use this for initialization
    void Start()
    {
        attackerPos = new Vector3(0, 100, -9);
        attackerRotate = new Quaternion(0, 90, 0, 0);
        damegerPos = new Vector3(0, 100, -1);
        damegerRotate = new Quaternion(0, -90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BattleSceneCreate()
    {

        counterNameText.text = counterName;

        CreateAttacker(PieceNum.PAWN, attackerPos, attackerRotate);

        switch (GamaManager.Instance.movieDate.counterPiece[0].piece_num)
        {

            case PieceNum.PAWN:

                counterName = "PAWN";

                break;

            case PieceNum.ROOK:

                counterName = "ROOK";

                break;

            case PieceNum.BISOP:

                counterName = "BISHOP";

                break;

            case PieceNum.KNIGHT:

                counterName = "KNIGHT";

                break;

            case PieceNum.QUEEN:

                counterName = "QUEEN";

                break;

            case PieceNum.KING:

                counterName = "KING";

                break;

            case PieceNum.JACK:

                counterName = "JACK";

                break;

        }

    }




    //////////////////////////////////攻撃側生成////////////////////////////////////////////

    public void CreateAttacker(PieceNum _attacker, Vector3 pos, Quaternion rotate)
    {
        GameObject obj = Instantiate(counter[(int)_attacker]);//これキャスト

        piece pic = obj.GetComponent<piece>();

        obj.transform.localPosition = pos;

        obj.transform.localRotation = rotate;

        pic.piece_num = _attacker;

        attackerNameText.text = attackerName;

        switch (GamaManager.Instance.movieDate.attackPiece[0].piece_num)
        {
            case PieceNum.PAWN:

                attackerName = "PAWN";

                break;

            case PieceNum.ROOK:

                attackerName = "ROOK";

                break;

            case PieceNum.BISOP:

                attackerName = "BISHOP";

                break;

            case PieceNum.KNIGHT:

                attackerName = "KNIGHT";

                break;

            case PieceNum.QUEEN:

                attackerName = "QUEEN";

                break;

            case PieceNum.KING:

                attackerName = "KING";

                break;

            case PieceNum.JACK:

                attackerName = "JACK";

                break;

        }

    }
    /// ///////////////////////////////////////////////////////////////////////////////////////
    /// 


    public void CreateDamagePiece(PieceNum _damagePiece, Vector3 pos, Quaternion rotate)
    {

        GameObject obj = Instantiate(counter[(int)_damagePiece]);//これキャスト

        piece pic = obj.GetComponent<piece>();

        obj.transform.localPosition = pos;

        obj.transform.localRotation = rotate;

        pic.piece_num = _damagePiece;

        damagerNameText.text = damagerName;

        switch (GamaManager.Instance.movieDate.damagePiece[0].piece_num)
        {
            case PieceNum.PAWN:

                damagerName = "PAWN";

                break;

            case PieceNum.ROOK:

                damagerName = "ROOK";

                break;

            case PieceNum.BISOP:

                damagerName = "BISHOP";

                break;

            case PieceNum.KNIGHT:

                damagerName = "KNIGHT";

                break;

            case PieceNum.QUEEN:

                damagerName = "QUEEN";

                break;

            case PieceNum.KING:

                damagerName = "KING";

                break;

            case PieceNum.JACK:

                damagerName = "JACK";

                break;

        }

    }


    public void CreateCounter(PieceNum _counter, Vector3 pos, Quaternion rotate)
    {

        GameObject obj = Instantiate(counter[(int)_counter]);//これキャスト

        piece pic = obj.GetComponent<piece>();

        obj.transform.localPosition = pos;

        obj.transform.localRotation = rotate;

        pic.piece_num = _counter;

        counterNameText.text = counterName;


        switch (GamaManager.Instance.movieDate.counterPiece[0].piece_num)
        {
            case PieceNum.PAWN:

                counterName = "PAWN";

                break;

            case PieceNum.ROOK:

                counterName = "ROOK";

                break;

            case PieceNum.BISOP:

                counterName = "BISHOP";

                break;

            case PieceNum.KNIGHT:

                counterName = "KNIGHT";

                break;

            case PieceNum.QUEEN:

                counterName = "QUEEN";

                break;

            case PieceNum.KING:

                counterName = "KING";

                break;

            case PieceNum.JACK:

                counterName = "JACK";

                break;

        }

    }


}