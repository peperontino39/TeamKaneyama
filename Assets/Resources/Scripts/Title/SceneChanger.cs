using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SoundManager.Instance.PlayBGM(SoundManager.BGM.TITLE);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.JoystickButton7)){
            SceneManager.LoadScene("MainMenuSample");
            SoundManager.Instance.StopBGM(SoundManager.BGM.TITLE);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenuSample");
            SoundManager.Instance.StopBGM(SoundManager.BGM.TITLE);
        }
	}

    public void OnClick()
    {
        SceneManager.LoadScene("MainMenuSample");
        
    }

}
