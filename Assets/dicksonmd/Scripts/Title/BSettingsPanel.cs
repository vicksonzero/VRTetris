using UnityEngine;
using System.Collections;

public class BSettingsPanel : MonoBehaviour {

    BGameConstants _constants;

    // Use this for initialization
    void Start () {
        this._constants = BGameConstants.getInstance();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setStartSpeed(float val)
    {
        this._constants.setStartSpeed(val);
    }

    public void setGameScale(float val)
    {
        this._constants.setGameScale(val);
    }

    public void setDebugOrientation(bool val)
    {
        this._constants.setDebugOrientation(val);
    }

    public void setDropButtonPosition(BGameConstants.DropButtonPositions val)
    {
        this._constants.setDropButtonPosition(val);
    }

    public void setLongPressHardDrop(bool val)
    {
        this._constants.setLongPressHardDrop(val);
    }

    public void setGhostBlock(bool val)
    {
        this._constants.setGhostBlock(val);
    }

    public void setDragCamera(bool val)
    {
        this._constants.setDragCamera(val);
    }

    public void setSmoothARCard(bool val)
    {
        this._constants.setSmoothARCard(val);
    }

}
