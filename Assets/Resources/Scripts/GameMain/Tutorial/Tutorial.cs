using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.UI;


public class Tutorial : MonoBehaviour
{

    [SerializeField]
    GameObject[] tutorialImage;

    [SerializeField]
    GameObject tutorialCanvas;

    int imageNum;

    int tutorialSwitch;


    [SerializeField]
    Text page_num;


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
            OpenClose();

        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            NaxtPage();
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            PrevPage();

        }


        if (tutorialSwitch >= 2)
        {
            tutorialSwitch = 0;
        }



        if (tutorialSwitch == 1)
        {
            tutorialCanvas.SetActive(true);
            SetTutorialImage(imageNum);
        

        }
        else if (tutorialSwitch == 0)
        {
            tutorialCanvas.SetActive(false);
        }


    }

    public void PrevPage()
    {
        SetTutorialImage(imageNum - 1);
    }

    public void NaxtPage()
    {
        SetTutorialImage(imageNum + 1);
    }

    public void OpenClose()
    {
        tutorialSwitch += 1;
    }

    void SetTutorialImage(int _imageNum)
    {

        tutorialImage[imageNum].SetActive(false);

        imageNum = _imageNum % 9;
        imageNum = Mathf.Max(imageNum, 0);

        page_num.text = (imageNum + 1).ToString();
        tutorialImage[imageNum].SetActive(true);
    }

    


}



