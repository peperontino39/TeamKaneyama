using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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


    void OnMouseEnter()
    {

    }

    void OnMouseExit()
    {


    }

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
    

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AddSelectSell(new Vector2(-1, 0));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AddSelectSell(new Vector2(1, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(selectSell.x == 0)
            {

            }
            if(selectSell.x == 1)
            {
                SceneManager.LoadScene("SetPieceMulti");
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

        }
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit = new RaycastHit();

        //if (Physics.Raycast(ray, out hit))
        //{
        //    GameObject obj = hit.collider.gameObject;
        //    Debug.Log(obj.name);
        //}


    }
}
