using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class SoundManager : MonoBehaviour
{

    public enum BGM
    {
        DADDY = 0,
    }

    public enum SE
    {
        OUT = 0,
        DEATH,
    }

    public static SoundManager Instance { get; private set; }

    [SerializeField]
    AudioSource[] bgmSources;

    [SerializeField]
    AudioSource[] seSources;

    [SerializeField]
    AudioClip[] clips;


    void Awake()
    {
        //if (GameObject.FindObjectOfType(SoundManager))
        //{
        //    Destroy(gameObject);
        //}
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {

    }


    public void PlaySE(SE se)
    {
        //seSources[(int)se].Play();


        int a = (int)se;

        SE s = (SE)System.Enum.ToObject(typeof(SE), a);
        //SoundManager.Instance.PlaySE(s);
        SoundManager.Instance.seSources[(int)s].Play();
    }

    public void PlayBGM(BGM bgm)
    {
        bgmSources[(int)bgm].Play();
    }

   

}