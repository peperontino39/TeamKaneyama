using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class SoundManager : MonoBehaviour
{

    public enum BGM
    {
        TITLE = 0,
        MAIN_ONE,
        MAIN_TWO,
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

        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }

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
        
        SoundManager.Instance.seSources[(int)s].Play();

        //Debug.Log("えすいー"+ se.ToString());

    }

    public void PlayBGM(BGM bgm)
    {
        bgmSources[(int)bgm].Play();
       // Debug.Log("BGM"+ bgm.ToString());
    }

    public void StopBGM(BGM bgm)
    {
        bgmSources[(int)bgm].Stop();
        //Debug.Log("BGM" + bgm.ToString());
    }

    public void BGMVolumeDown(BGM  bgm,float _volume)
    {
        bgmSources[(int)bgm].volume = _volume;
    }



}