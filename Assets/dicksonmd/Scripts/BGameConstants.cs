using UnityEngine;
using System.Collections;

public class BGameConstants : MonoBehaviour {
   

    [Header("Version")]
    public string gameName = "VRTetris";
    public string versionName = "v0_4";
    public int buildNumber = 4;

    [Header("game size")]
    public int width = 6;   // x
    public int height = 14;  // y
    public int depth = 7;   // z

    static BGameConstants instance = null;
    public static BGameConstants getInstance()
    {
        return instance;
    }
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
}
