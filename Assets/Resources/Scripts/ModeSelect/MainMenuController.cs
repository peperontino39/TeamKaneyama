using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public int cursorCount;
    
    
    public Image tutorialImage;
    public Image singlePlayImage;
    public Image multiPlayImage;
    public Text tutorialText;
    public Text singlePlayText;
    public Text multiPlayText;



    // Use this for initialization
    void Start () {
        cursorCount = 0;
      
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(cursorCount);

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            cursorCount +=1;

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            cursorCount -= 1;

        }


        if (cursorCount > 2)
        {
            cursorCount = 0;
        }
        if (cursorCount < 0)
        {
            cursorCount = 2;
        }


        switch (cursorCount) {

            case 0:

                tutorialImage.color = new Color(0.2f, 0.2f, 0.2f);
                singlePlayImage.color = new Color(1.0f, 1.0f, 1.0f);
                multiPlayImage.color = new Color(0.2f, 0.2f, 0.2f);
                tutorialText.color = new Color(0.2f, 0.2f, 0.2f);
                singlePlayText.color = new Color(1.0f, 0.0f, 0.0f); 
                multiPlayText.color = new Color(0.2f, 0.2f, 0.2f);

                if (Input.GetKeyUp(KeyCode.KeypadEnter)) {

                    SceneManager.LoadScene("GameMain");

                }
                

                break;

            case 1:

                tutorialImage.color = new Color(0.2f, 0.2f, 0.2f);
                singlePlayImage.color = new Color(0.2f, 0.2f, 0.2f);
                multiPlayImage.color = new Color(1.0f, 1.0f, 1.0f);
                tutorialText.color = new Color(0.2f, 0.2f, 0.2f);
                singlePlayText.color = new Color(0.2f, 0.2f, 0.2f);
                multiPlayText.color = new Color(1.0f, 0.0f, 0.0f);


                if (Input.GetKeyUp(KeyCode.KeypadEnter))
                {

                    SceneManager.LoadScene("GameMain");

                }
               
                break;

            case 2:

                tutorialImage.color = new Color(1.0f, 1.0f, 1.0f);
                singlePlayImage.color = new Color(0.2f, 0.2f, 0.2f);
                multiPlayImage.color = new Color(0.2f, 0.2f, 0.2f);
                tutorialText.color = new Color(1.0f, 0.0f, 0.0f);
                singlePlayText.color = new Color(0.2f, 0.2f, 0.2f);
                multiPlayText.color = new Color(0.2f, 0.2f, 0.2f);


                if (Input.GetKeyUp(KeyCode.KeypadEnter))
                {

                    SceneManager.LoadScene("GameMain");

                }


                break;

        }


    }

 
}
