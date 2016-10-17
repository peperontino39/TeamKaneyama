using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class piece : MonoBehaviour
{
    private CreateBoard board;

    public Vector2 sell = Vector2.zero;

    public List<areaBase> areas = new List<areaBase>();


    public void setSell(Vector2 _go_sell)
    {
        board.moveSell(sell, _go_sell);
        sell = _go_sell;
        transform.position = board.getSellPosition(_go_sell);

    }

    
    void Start()
    {
        board = GameObject.Find("Board").GetComponent<CreateBoard>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            setSell(sell);

        }

    }
}
