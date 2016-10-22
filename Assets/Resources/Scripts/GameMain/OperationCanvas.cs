using UnityEngine;
using System.Collections;

public class OperationCanvas : MonoBehaviour
{

    public Camera rotateCamera;
    void Start()
    {
        rotateCamera = Camera.main;
    }
    void Update()
    {
        transform.rotation = rotateCamera.transform.rotation;
    }
    void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
