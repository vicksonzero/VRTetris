using UnityEngine;
using System.Collections;

public class BGameConstants : MonoBehaviour {
   

    [Header("Version")]
    public string gameName = "VRTetris";
    public string versionName = "v0.8";
    public int buildNumber = 10;

    [Header("game size")]
    public int width = 5;   // x
    public int height = 14;  // y
    public int depth = 5;   // z

    [Header("Game Settings")]
    public float startSpeed = 1.5f;
    public float gameScale = 1f;
    public bool debugOrientation = false;
    public enum DropButtonPositions { ceil , floor, screenRight, screenLeft};
    public DropButtonPositions dropButtonPosition = DropButtonPositions.ceil;
    public bool longPressHardDrop = true;
    public bool ghostBlock = true;
    public bool dragCamera = false;
    public bool smoothARCard = false;

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

    public void setStartSpeed(float val)
    {
        this.startSpeed = val;
    }
    public void setGameScale(float val)
    {
        this.gameScale = val;
    }
    public void setDebugOrientation(bool val)
    {
        this.debugOrientation = val;
    }
    public void setDropButtonPosition(DropButtonPositions val)
    {
        this.dropButtonPosition = val;
    }
    public void setLongPressHardDrop(bool val)
    {
        this.longPressHardDrop = val;
    }
    public void setGhostBlock(bool val)
    {
        this.ghostBlock = val;
    }
    public void setDragCamera(bool val)
    {
        this.dragCamera = val;
    }
    public void setSmoothARCard(bool val)
    {
        this.smoothARCard = val;
    }
}
