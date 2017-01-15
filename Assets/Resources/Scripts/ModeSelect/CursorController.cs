using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

using System;

public class CursorController : MonoBehaviour
{
    [SerializeField]
    GameObject cursor;

    public Vector2 selectSell = new Vector2(0,0);


    [System.SerializableAttribute]
    public class ValueList
    {
        public List<GameObject> List;
    }

    [SerializeField]
    public List<ValueList> selectObject;

    [SerializeField]
    UnityEvent open;

    [SerializeField]
    UnityEvent Next;

    [SerializeField]
    UnityEvent Prev;

    [SerializeField]
    GameObject tutorial;



    void Start()
    {

        AddSelectSell(new Vector2(0, 0));
    }
    
    void AddSelectSell(Vector2 addSell)
    {
        selectSell += addSell;

        selectSell.y = Mathf.Min(Mathf.Max(selectSell.y, 0), selectObject.Count-1);
        selectSell.x = Mathf.Min(Mathf.Max(selectSell.x, 0), selectObject[(int)selectSell.y].List.Count-1);

        cursor.transform.position = 
            selectObject[(int)selectSell.y].List[(int)selectSell.x].
            transform.position + new Vector3(0,-80,0);

    }

    bool axis = true;
    bool aButtonFlag = true;


    void Update()
    {
        if (!axis)
        {
            if((int)Input.GetAxis("GamePad_Left_Axis_x") != 0)
            {
                if (!tutorial.activeSelf)
                {

                    AddSelectSell(new Vector2((int)Input.GetAxis("GamePad_Left_Axis_x"), 0));
                }
                else
                {
                    if((int)Input.GetAxis("GamePad_Left_Axis_x") == 1)
                    {
                        Next.Invoke();
                    }
                    else
                    {
                        Prev.Invoke();
                    }
                }
            }
        }
       
        if (!aButtonFlag)
        {
            if (!Input.GetKey("joystick button 0"))
            {
                if (selectSell.x == 0)
                {
                    open.Invoke();
                }
                if (selectSell.x == 1)
                {
                    SceneManager.LoadScene("SetPieceMulti");
                }
            }
        }
       
       
        axis = (int)Input.GetAxis("GamePad_Left_Axis_x") != 0 ;
        aButtonFlag = !Input.GetKey("joystick button 0");

    }
}
