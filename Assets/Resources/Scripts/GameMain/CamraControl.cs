using UnityEngine;
using System.Collections;

public class CamraControl : MonoBehaviour {

    public Vector2 angle;
	void Start () {

        angle = new Vector2(44.0f,-90.0f);

    }

    
	void Update () {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angle.y++;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angle.y--;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            angle.x++;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            angle.x--;
        }

        transform.LookAt(
           Quaternion.AngleAxis(angle.y, Vector3.up) *
           Quaternion.AngleAxis(angle.x, Vector3.right) *
           Vector3.forward + transform.position);


    }
}
