using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class BSettingsSlidingValue : BSettingControl {

    [System.Serializable]
    public class myFloatEvent : UnityEvent<float> { }

    public string key;

    [SerializeField]
    public myFloatEvent onUpdated;

    [HideInInspector]
    public Slider slider;
    [HideInInspector]
    public InputField inputField;


    // Use this for initialization
    void Start () {
        slider = this.GetComponentInChildren<Slider>();
        inputField = this.GetComponentInChildren<InputField>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onUpdate(float val)
    {
        inputField.text = val.ToString("0.##"); ;
        slider.value = val;
        onUpdated.Invoke(val);
    }
    public void onUpdate(string val)
    {
        var valParsed = Convert.ToSingle(val);
        inputField.text = valParsed.ToString("0.##"); ;
        slider.value = valParsed;
        onUpdated.Invoke(valParsed);
    }
}
