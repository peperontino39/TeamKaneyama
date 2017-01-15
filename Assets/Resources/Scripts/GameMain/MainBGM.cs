using UnityEngine;
using System.Collections;

public class MainBGM : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SoundManager.Instance.PlayBGM(SoundManager.BGM.MAIN_ONE);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
