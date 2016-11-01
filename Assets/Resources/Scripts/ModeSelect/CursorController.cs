using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour {


    [SerializeField]
    Texture2D cursorTexture;

    CursorMode cursorMode = CursorMode.Auto;

    Vector2 position = Vector2.zero;
    
    
    void OnMouseEnter()
    {

        //Cursor.SetCursor(cursorTexture, position,cursorMode);

    }

    void OnMouseExit()
    {

        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        
    }
   

    // Use this for initialization
    void Start()
    {

        Cursor.SetCursor(cursorTexture, position, cursorMode);
        Cursor.visible = true;

    }

    // Update is called once per frame
    void Update()
    {

        Cursor.visible = true;

       

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                Debug.Log(obj.name);
            }
        

    }
}
