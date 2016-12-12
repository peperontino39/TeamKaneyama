using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMainData : MonoBehaviour {



    public List<List<OnPieceDate>> player1;
    public List<List<OnPieceDate>> player2;

    private static GameMainData instance;

    public static GameMainData Instance
    {
        get
        {

            if (instance == null)
            {
                GameObject go = new GameObject("GamaManager");
                instance = go.AddComponent<GameMainData>();
            }
            return instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }
}
