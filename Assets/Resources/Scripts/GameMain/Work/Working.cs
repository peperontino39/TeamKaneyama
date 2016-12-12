using UnityEngine;
using System.Collections;

public class Working : MonoBehaviour {

    [SerializeField]
    GameObject workCharacter;

    Vector3 workPos;

    bool workSwitch;

	// Use this for initialization
	void Start () {

        workPos = new Vector3(0,200,-5);

        workSwitch = false;
	
	}
	
	// Update is called once per frame
	void Update () {

        workCharacter.transform.position = workPos;

        if (Input.GetKey(KeyCode.W))
        {
            workSwitch = true;
        }

        if (workSwitch == true)
        {
            workPos.z += 0.03f;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            workSwitch = true;

            workPos = new Vector3(0, 200, -5);
        }
    }
}
