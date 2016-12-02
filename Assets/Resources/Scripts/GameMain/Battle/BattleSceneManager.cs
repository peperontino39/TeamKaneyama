using UnityEngine;
using System.Collections;

public class BattleSceneManager : MonoBehaviour {

    [SerializeField]
    GameObject battleCamera;
    [SerializeField]
    GameObject mainCamera;
    [SerializeField]
    GameObject mainCanvas;
    [SerializeField]
    GameObject battleCanvas;
    [SerializeField]
    GameObject workCamera;
    [SerializeField]
    GameObject workCanvas;

    int cameraNum;
   
	// Use this for initialization
	void Start () {

        cameraNum = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

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

                battleCamera.SetActive(false);
                battleCanvas.SetActive(false);
                mainCamera.SetActive(true);
                mainCanvas.SetActive(true);
                workCamera.SetActive(false);
                workCanvas.SetActive(false);
                break;

            case 1:

                battleCamera.SetActive(true);
                battleCanvas.SetActive(true);
                mainCamera.SetActive(false);
                mainCanvas.SetActive(false);
                workCamera.SetActive(false);
                workCanvas.SetActive(false);

                break;

            case 2:

                battleCamera.SetActive(false);
                battleCanvas.SetActive(false);
                mainCamera.SetActive(false);
                mainCanvas.SetActive(false);
                workCamera.SetActive(true);
                workCanvas.SetActive(true);

                break;

        }


    }
}
