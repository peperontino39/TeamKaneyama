using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetBoard : MonoBehaviour
{

    [SerializeField]
    GameObject sell;

    [SerializeField]
    GameObject canvas;


    [SerializeField]
    Select select;
    
    void Start()
    {
        for (int y = 0; y < 3; y++)
        {
            List<OnPieceDate> line = new List<OnPieceDate>();
            for (int x = 0; x < 11; x++)
            {
                GameObject obj = Instantiate(sell);
                obj.transform.position = new Vector3(x * 60 - 300, 150 - y * 60, 0);
                obj.transform.SetParent(canvas.transform, false);
                line.Add(obj.GetComponent<OnPieceDate>());
            }
            select.onPiece.Add(new List<OnPieceDate>(line));
        }
    }

    void Update()
    {
        
    }
}
