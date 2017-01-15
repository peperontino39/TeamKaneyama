using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{

    int num = 0;
    [SerializeField]
    GameObject[] piece;

    Vector2 selectSell = new Vector2(0, 0);


    [SerializeField]
    Transform icon;

    public List<List<OnPieceDate>> onPiece = new List<List<OnPieceDate>>();

    [SerializeField]
    Transform selectSellPosition;

    [SerializeField]
    GameObject canvas;


    [SerializeField]
    GameObject IsOkWindow;

    PieceNum catchPiese = PieceNum.NON;
    public GameObject selectImage;


    //残量
    [SerializeField]
    public int[] remainingAmount;
    public Text[] remainingAmountText;



    private void TextWrite()
    {
        for (int i = 0; i < piece.Length; i++)
        {
            remainingAmountText[i].text = remainingAmount[i].ToString();
        }
    }

    [SerializeField]
    public string gamepadname_x;
    [SerializeField]
    public string gamepadname_y;
    [SerializeField]
    public string gamepadname_a;
    [SerializeField]
    public string gamepadname_start;



    bool axis;
    bool aButtonFlag = false;
    bool gamepadnameStartFlag = false;

    public bool is_set_ok = false;

    void Start()
    {
        AddNum(0, 0);

        TextWrite();
        axis = false;
    }

    void Update()
    {

        // Debug.Log(Input.GetAxis(gamepadname_x));
        if (!axis)
        {
            if ((int)Input.GetAxis(gamepadname_x) != 0 || (int)Input.GetAxis(gamepadname_y) != 0)
            {
                AddNum((int)Input.GetAxis(gamepadname_x), (int)Input.GetAxis(gamepadname_y));
            }
        }

        if (!aButtonFlag)
        {
            if (Input.GetAxis(gamepadname_a) != 0)
            {
                Determination();
            }
        }

        Debug.Log(Input.GetAxis("GamePad1_start"));
        if (Input.GetAxis(gamepadname_start) == 1)
        {
            int totle = 0;
            foreach (var num in remainingAmount)
            {
                totle += num;
            }
            //Debug.Log(is_set_ok);
            is_set_ok = true;
            IsOkWindow.SetActive(true);

        }

        icon.transform.SetAsLastSibling();  //アイコンを一番前に出す
        if (selectImage != null)
        {
            selectImage.transform.position = icon.position + Vector3.up * 0;
        }
        axis = (int)Input.GetAxis(gamepadname_x) != 0 || (int)Input.GetAxis(gamepadname_y) != 0;
        aButtonFlag = Input.GetAxis(gamepadname_a) != 0;

    }
    //決定ボタンを押したときの処理です
    private void Determination()
    {
        //何も持ってないとき
        if (catchPiese == PieceNum.NON)
        {
            //セルを指している時
            if (num == -1)
            {
                if (onPiece[(int)selectSell.y][(int)selectSell.x].onPiece != PieceNum.NON)
                {
                    selectImage = onPiece[(int)selectSell.y][(int)selectSell.x].onPieceImage;
                    onPiece[(int)selectSell.y][(int)selectSell.x].onPieceImage = null;
                    catchPiese = onPiece[(int)selectSell.y][(int)selectSell.x].onPiece;
                }
            }

            //セルを指してないとき
            else
            {
                if (remainingAmount[num] > 0)
                {
                    remainingAmount[num]--;
                    selectImage = Instantiate(piece[num]);

                    selectImage.transform.SetParent(canvas.transform, false);
                    catchPiese = selectImage.GetComponent<OnPieceDate>().onPiece;
                }
            }
        }
        //何かもってるとき
        else
        {
            //セルを指している時
            if (num == -1)
            {

                if (onPiece[(int)selectSell.y][(int)selectSell.x].onPieceImage != null)
                {
                    remainingAmount[(int)onPiece[(int)selectSell.y][(int)selectSell.x].onPiece]++;
                    Destroy(onPiece[(int)selectSell.y][(int)selectSell.x].onPieceImage);
                }
                onPiece[(int)selectSell.y][(int)selectSell.x].onPieceImage = selectImage;
                //Debug.Log(selectImage);
                selectImage.transform.position = onPiece[(int)selectSell.y][(int)selectSell.x].transform.position;
                catchPiese = PieceNum.NON;
                onPiece[(int)selectSell.y][(int)selectSell.x].onPiece =
                    selectImage.GetComponent<OnPieceDate>().onPiece;

                selectImage = null;
            }
            //セルを指してないとき
            else
            {
                remainingAmount[(int)catchPiese]++;

                Destroy(selectImage);
                catchPiese = PieceNum.NON;
                selectImage = null;
            }
        }
        TextWrite();


    }

    private void AddNum(int x, int y)
    {
        if (num == -1)
        {

            if (selectSell.y + y >= 3)
            {
                num = 0;
                icon.position = piece[num].transform.position + Vector3.up * 30;
            }
            else
            {

                selectSell.x += x;
                selectSell.y += y;
                selectSell.x = Mathf.Min(Mathf.Max(selectSell.x, 0), 8);

                selectSell.y = Mathf.Max(selectSell.y, 0);
                icon.position = onPiece[(int)selectSell.y][(int)selectSell.x].gameObject.transform.position + Vector3.up * 30;
            }

        }
        else
        {
            if (num + x + y * 5 > piece.Length - 1) return;
            if (num + x + y * 5 < 0)
            {
                num = -1;
                icon.position = onPiece[(int)selectSell.y][(int)selectSell.x].gameObject.transform.position + Vector3.up * 30;
                return;
            }

            num += x + y * 5;
            num = Mathf.Min(Mathf.Max(num, 0), piece.Length - 1);

            icon.position = piece[num].transform.position + Vector3.up * 30;
        }
    }


}
