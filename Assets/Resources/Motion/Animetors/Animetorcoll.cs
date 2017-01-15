using UnityEngine;
using System.Collections;

public class Animetorcoll : MonoBehaviour
{

    [SerializeField]
    Animator anim;

    // Use this for initialization

    [SerializeField]
    string[] animetioName;

    [SerializeField]
    float[] rotateRip;

    int playAnimNum;



    public int PlayAnimNum
    {
        get { return playAnimNum; }
        set
        {
            if (value >=4)
            {
                foreach (var i in animetioName)
                {
                    anim.SetBool(i, false);
                }
                playAnimNum = 4;
            }
            else {
                if (playAnimNum <4)
                {
                    anim.SetBool(animetioName[playAnimNum], false);
                }
                playAnimNum = value;

              
                transform.rotation = Quaternion.Euler(0, rotateRip[playAnimNum], 0);
                anim.SetBool(animetioName[playAnimNum], true);
            }
        }
    }
    void Start()
    {
        PlayAnimNum = 5;
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayAnimNum = 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayAnimNum = 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayAnimNum = 2;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayAnimNum = 3;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayAnimNum = 4;
        }

        
    }
}
