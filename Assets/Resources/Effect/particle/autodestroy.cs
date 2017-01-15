using UnityEngine;
using System.Collections;

public class autodestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        ParticleSystem particleSystem = GetComponent<ParticleSystem>();

        Destroy(gameObject,1.0f);
	
	}
}
