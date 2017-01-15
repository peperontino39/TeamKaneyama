using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {


    
  
    public Vector2 sell;

    public int team_num;

    public bool is_open = false;
    public bool is_in_piece = false;



    public void SetSell(Vector2 _sell)
    {
        transform.position = GamaManager.Instance.Board.getSellPosition(_sell);
        
        sell = _sell;
    }

    public void setTeam(int num)
    {
        team_num = num;
        if (team_num == 1)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0);
        }

    }

   

    void Start () {
        SetSell(sell);

        
    }
	
	void Update () {
	
	}
}
