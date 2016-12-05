using UnityEngine;
using System.Collections;

public class BattleSceneManager : MonoBehaviour {

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

    Vector3 cameraPos;
    Vector3 fieldPos;

    float zoomSensitivity;
   
	// Use this for initialization
	void Start () {

        cameraNum = 0;

        fieldPos = new Vector3(-250.0f, 0.0f, -250.0f);
        cameraPos = new Vector3(4.0f, 0.0f, 4.0f);

        
	
	}
	
	// Update is called once per frame
	void Update () {

        field.transform.localPosition = fieldPos;

        mainCamera.transform.localPosition = cameraPos;

        mainCamera.gameObject.GetComponentInChildren<Camera>().fieldOfView = zoomSensitivity;

        if (Input.GetKeyUp(KeyCode.A))
        {
            cameraNum +=1;
        }

        if (cameraNum > 2)
        {
            cameraNum = 0;
        }

        switch (cameraNum) {

            case 0:

               
                battleCanvas.SetActive(false);
                mainCanvas.SetActive(true);
                workCanvas.SetActive(false);
                fieldPos = new Vector3(-250.0f, 0.0f, -250.0f);
                cameraPos = new Vector3(4.0f, 0.0f, 4.0f);
                zoomSensitivity = 60.0f;

                break;

            case 1:

         
                battleCanvas.SetActive(true);
                mainCanvas.SetActive(false);
                workCanvas.SetActive(false);
                fieldPos = new Vector3(-240.0f, 100.0f, -300.0f);
                cameraPos = new Vector3(0.0f, 102.0f, -5.0f);
                zoomSensitivity = 30.0f;

                break;

            case 2:

               
                battleCanvas.SetActive(false);
                mainCanvas.SetActive(false);
                workCanvas.SetActive(true);
                fieldPos = new Vector3(-250.0f, 200.0f, -320.0f);
                cameraPos = new Vector3(4.0f, 202.0f, -8.0f);
                zoomSensitivity = 60.0f;

                break;

        }


    }
}
