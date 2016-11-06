using UnityEngine;
using System.Collections;

public class MinMenuManager : MonoBehaviour {

    

    public void CreateMenu()
    {

    }






    static private MinMenuManager instance;

    public static MinMenuManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GamaManager");
                instance = go.AddComponent<MinMenuManager>();
            }

            return instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }
}
