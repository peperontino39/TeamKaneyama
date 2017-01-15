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

    PieceNum catchPiese = PieceNum.NON;
    public GameObject selectImage;


    //残量
    [SerializeField]
    public int[] remainingAmount;
    public Text[] remainingAmountText;

    bool is_ok = false;



    void Start()
    {
        AddNum(0, 0);

        TextWrite();
    }

    private void TextWrite()
    {
        for (int i = 0; i < piece.Length; i++)
        {
            remainingAmountText[i].text = remainingAmount[i].ToString();
        }
    }

    int gamepad1_left_axisx;
    int gamepad1_left_axisy;

    [SerializeField]
    public string gamepadname_x;
    [SerializeField]
    public string gamepadname_y;
    [SerializeField]
    public string gamepadname_a;



    void Update()
    {


        //Debug.Log(Input.GetAxis("GamePad1_Left_Axis_y"));
        Debug.Log(Input.GetAxis(gamepadname_a));

        if (gamepad1_left_axisx == (int)Input.GetAxisRaw(gamepadname_x))
        {
            gamepad1_left_axisx = 0;
        }
        if (gamepad1_left_axisy == (int)Input.GetAxisRaw(gamepadname_y))
        {
            gamepad1_left_axisy = 0;
        }
        if (gamepad1_left_axisx != 0)
        {
            AddNum(gamepad1_left_axisx, 0);
        }
        if (gamepad1_left_axisy != 0)
        {
            AddNum(0, gamepad1_left_axisy);
        }



        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    AddNum(-1, 0);

        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    AddNum(1, 0);
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    AddNum(0, 1);
        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    AddNum(0, -1);

        //}
        if (gamepadname_x == "GamePad2_Left_Axis_x")
        {
            if (Input.GetKeyDown(KeyCode.Joystick2Button0))
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
                        Debug.Log(selectImage);
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

            if (Input.GetKeyDown(KeyCode.Joystick2Button7))
            {
                int totle = 0;
                foreach (var num in remainingAmount)
                {
                    totle += num;
                }
                //if (totle == 0)
                //{

                GameMainData.Instance.player2 = new List<List<OnPieceDate>>(onPiece);

                SceneManager.LoadScene("GameMain");
                //}
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
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
                        Debug.Log(selectImage);
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

            if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                int totle = 0;
                foreach (var num in remainingAmount)
                {
                    totle += num;
                }
                //if (totle == 0)
                //{

                GameMainData.Instance.player1 = new List<List<OnPieceDate>>(onPiece);

                SceneManager.LoadScene("GameMain");
                //}
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            Debug.Log("fghj");
        }
            icon.transform.SetAsLastSibling();


        if (selectImage != null)
        {
            selectImage.transform.position = icon.position + Vector3.up * 30;
        }

        gamepad1_left_axisx = (int)Input.GetAxisRaw(gamepadname_x);
        gamepad1_left_axisy = (int)Input.GetAxisRaw(gamepadname_y);



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
