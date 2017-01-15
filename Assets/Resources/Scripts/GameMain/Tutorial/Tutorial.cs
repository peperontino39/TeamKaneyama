using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour
{

    [SerializeField]
    GameObject[] tutorialImage;

    [SerializeField]
    GameObject tutorialCanvas;

    int imageNum;

    int tutorialSwitch;


    // Use this for initialization
    void Start()
    {
        foreach (var i in tutorialImage)
        {
            i.SetActive(false);
        }



        tutorialSwitch = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Y))
        {
            tutorialSwitch += 1;

        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            SetTutorialImage(imageNum + 1);
            Debug.Log("おした");


        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            SetTutorialImage(imageNum - 1);


        }


        if (tutorialSwitch >= 2)
        {
            tutorialSwitch = 0;
        }



        if (tutorialSwitch == 1)
        {
            tutorialCanvas.SetActive(true);
            SetTutorialImage(imageNum);
            Debug.Log("でた");

        }
        else if (tutorialSwitch == 0)
        {
            tutorialCanvas.SetActive(false);
        }


    }


    void SetTutorialImage(int _imageNum)
    {

        tutorialImage[imageNum].SetActive(false);

        imageNum = _imageNum % 10;
        imageNum = Mathf.Max(imageNum, 0);

        tutorialImage[imageNum].SetActive(true);



    }


}



