using UnityEngine;
using System.Collections;

public class Drag_Drop : MonoBehaviour {

    private bool nowMouseEnter;

	// Use this for initialization
	void Start () {
        nowMouseEnter = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseEnter()
    {
        nowMouseEnter = true;
    }

    void OnMouseExit()
    {
        nowMouseEnter = false;
    }
}
