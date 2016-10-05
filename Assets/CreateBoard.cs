using UnityEngine;
using System.Collections;
using System;

public class CreateBoard : MonoBehaviour
{
    [SerializeField]
    Vector2 size;


    void Start()
    {
        for (int z= 0; z< size.y; z++)
        {
            for(int x = 0; x < size.x; x++)
            {
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(x, 0, z);
                int col = Convert.ToInt32((x + z)% 2 == 0);
                cube.GetComponent<Renderer>().material.color = Color.white * col;
                cube.AddComponent<SellDate>();
            }
        }
    }

    void Update()
    {

    }
}
