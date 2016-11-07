using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KingsInfo : MonoBehaviour {

    public List<piece> kings;
	public int WinTeam()
    {
       foreach(var king in kings)
        {
            if(king.life <= 0)
            {
                return king.team_number;
            }
        }

        return -1;
    }

}
