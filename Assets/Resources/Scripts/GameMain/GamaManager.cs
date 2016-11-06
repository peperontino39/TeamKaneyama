using UnityEngine;
using System.Collections;

public class GamaManager : MonoBehaviour
{
    [SerializeField]
    public CreateBoard Board;

    [SerializeField]
    public Team team;

    [SerializeField]
    public Castles castles;


    static GamaManager instance;

    public static GamaManager Instance
    {
        get
        {

            if (instance == null)
            {
                GameObject go = new GameObject("GamaManager");
                instance = go.AddComponent<GamaManager>();
            }

            return instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }
}
