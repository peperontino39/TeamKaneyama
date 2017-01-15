using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class setPieceSceneChange : MonoBehaviour
{
    [SerializeField]
    Select player1;

    [SerializeField]
    Select player2;

    void Start()
    {

    }

    void Update()
    {
        if (player1.is_set_ok && player2.is_set_ok)
        {
            GameMainData.Instance.player1 = new List<List<OnPieceDate>>(player1.onPiece);
            GameMainData.Instance.player2 = new List<List<OnPieceDate>>(player2.onPiece);
            SceneManager.LoadScene("GameMain");
        }

    }
}
