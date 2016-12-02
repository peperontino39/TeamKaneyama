using UnityEngine;
using System.Collections;

public class BordManager : MonoBehaviour {

    public int bordPieceCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(bordPieceCount);

        if (bordPieceCount>=27)
        {
            Debug.Log("うまった");
        }
	
	}

    public void SetPieceCount()
    {

        bordPieceCount += 1;

    }
}
