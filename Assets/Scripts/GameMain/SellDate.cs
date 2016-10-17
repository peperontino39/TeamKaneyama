using UnityEngine;
using System.Collections;

public class SellDate : MonoBehaviour
{

    enum Status
    {
        NON,
        NORMAL,

    }

    public bool is_movable = false;
    public Vector2 sell;
    private Status status;
    public GameObject on_pise;


    public GameObject SelectQuad;

    public void SetStatus(int type)
    {
        status = (Status)type;
    }



    void Start()
    {
        SelectQuad = gameObject.transform.FindChild("SelectQuad").gameObject;

        setMovable(false);


    }

    void Update()
    {


    }
    public void setMovable(bool _movable)
    {
        is_movable = _movable;
        SelectQuad.SetActive(_movable);
    }
   
    
}
