using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {



    [SerializeField]
    CreateBoard board;
    public Vector2 sell;

    public int team_num;

    public void SetSell(Vector2 _sell)
    {
        transform.position = board.getSellPosition(_sell);
        
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

    void Awake(){
        board = GameObject.Find("Board").GetComponent<CreateBoard>();

    }

    void Start () {
        SetSell(sell);

        board.AddCastle(this);
    }
	
	void Update () {
	
	}
}
