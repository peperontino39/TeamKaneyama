using UnityEngine;
using System.Collections;

public class SoundTest : MonoBehaviour {

    public AudioClip audioClip;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;

    }
	
	// Update is called once per frame
	void Update () {
     

        if (Input.GetKey(KeyCode.A)) {

            SoundManager.Instance.PlaySE(SoundManager.SE.OUT);
          
        }
	}
}
