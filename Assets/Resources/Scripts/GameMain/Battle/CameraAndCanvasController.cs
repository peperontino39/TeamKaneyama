using UnityEngine;
using System.Collections;

public class CameraAndCanvasController : MonoBehaviour {

    CamraControl camraControl;

    [SerializeField]
    GameObject mainCamera;
    [SerializeField]
    GameObject mainCanvas;
    [SerializeField]
    GameObject battleCanvas;
    [SerializeField]
    GameObject workCanvas;
    [SerializeField]
    GameObject field;

    int cameraNum;
    float zoomSensitivity;
    bool isControll;
    public Vector2 angle;
    Vector3 cameraPos;
    Vector3 fieldPos;
    
    // Use this for initialization
    void Start () {

        cameraNum = 0;

        isControll = true;

        fieldPos = new Vector3(-250.0f, 0.0f, -250.0f);

        cameraPos = new Vector3(4.0f, 0.0f, 4.0f);

        angle = new Vector2(44.0f, -90.0f);

    }
	
	// Update is called once per frame
	void Update () {

        field.transform.localPosition = fieldPos;

        mainCamera.transform.localPosition = cameraPos;

        mainCamera.gameObject.GetComponentInChildren<Camera>().fieldOfView = zoomSensitivity;

        transform.LookAt(
          Quaternion.AngleAxis(angle.y, Vector3.up) *

          Quaternion.AngleAxis(angle.x, Vector3.right) *

          Vector3.forward + transform.position);

///////////////////////////////////////////////////////////////////////////////////////////

        //カメラ操作
        if (isControll == true) {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                angle.y++;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                angle.y--;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                angle.x++;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                angle.x--;
            }
        }

///////////////////////////////////////////////////////////////////////////////////////////

        //デバッグ用シーン切り替え
        if (Input.GetKeyUp(KeyCode.Space))
        {
            cameraNum +=1;
        }

        if (cameraNum > 2)
        {
            cameraNum = 0;
        }

///////////////////////////////////////////////////////////////////////////////////////////////

        //シーンごとのキャンバス切り替えとカメラとフィールドのposチェンジ
        switch (cameraNum) {

            case 0:

                isControll = true;
                battleCanvas.SetActive(false);
                mainCanvas.SetActive(true);
                workCanvas.SetActive(false);
                fieldPos = new Vector3(-250.0f, 0.0f, -250.0f);
                cameraPos = new Vector3(4.0f, 0.0f, 4.0f);
                zoomSensitivity = 60.0f;

                break;

            case 1:

                isControll = true;
                battleCanvas.SetActive(true);
                mainCanvas.SetActive(false);
                workCanvas.SetActive(false);
                fieldPos = new Vector3(-240.0f, 100.0f, -300.0f);
                cameraPos = new Vector3(0.0f, 102.0f, -5.0f);
                angle = new Vector2(15.0f, -50.0f);
                zoomSensitivity = 50.0f;

                break;

            case 2:

                isControll = false;
                battleCanvas.SetActive(false);
                mainCanvas.SetActive(false);
                workCanvas.SetActive(true);
                fieldPos = new Vector3(-230.0f, 200.0f, -285.0f);
                cameraPos = new Vector3(0.0f, 201.0f, 0.0f);
                angle = new Vector2(0.0f, -120.0f);
                zoomSensitivity = 30.0f;

                break;

        }
//////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
