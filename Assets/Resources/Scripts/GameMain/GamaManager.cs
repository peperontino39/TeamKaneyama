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

    [SerializeField]
    public CommandList command_list;

    [SerializeField]
    public KingsInfo kings_info;

    //ムービーに使う情報
    public MoveDate movieDate = new MoveDate();

    [SerializeField]
    public GameObject SelectObject;


    [SerializeField]
    public CameraAndCanvasController cameraAndCanvasController;




    public enum SceneNum
    {
        MainGame,
        WorkScene,
        AttackScene,
        CounterScene
    }

    public SceneNum sceneNum;

    private static GamaManager instance;

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
        instance = this;
    }
}
