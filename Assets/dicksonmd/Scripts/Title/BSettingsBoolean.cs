using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class BSettingsBoolean : BSettingControl {

    [System.Serializable]
    public class myFloatEvent : UnityEvent<bool> { }

    public string key;

    [SerializeField]
    public myFloatEvent onUpdated;

    [HideInInspector]
    public Toggle toggle;


    // Use this for initialization
    void Start () {
        toggle = this.GetComponentInChildren<Toggle>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onUpdate(bool val)
    {
        onUpdated.Invoke(val);
    }
}
