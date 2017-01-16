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

    public void StartAnim(int _anim_num, float _wait, float _time)
    {
        StartCoroutine(Animcoll(_anim_num, _wait, _time));
    }

    IEnumerator Animcoll(int _anim_num , float _wait ,float _time)
    {
        yield return new WaitForSeconds(_wait);
        PlayAnimNum = _anim_num;
        yield return new WaitForSeconds(_time);
        PlayAnimNum = 4;
    }

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

              
                transform.localRotation = Quaternion.Euler(0, rotateRip[playAnimNum], 0);
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
        
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    PlayAnimNum = 0;
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    PlayAnimNum = 1;
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    PlayAnimNum = 2;
        //}
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    PlayAnimNum = 3;
        //}
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    PlayAnimNum = 4;
        //}

        
    }
}
