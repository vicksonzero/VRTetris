using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class BTitle : MonoBehaviour
{
    public string nextSceneName;
    public Text titleLabel;
    public Text titleLabel2;
    public Text buildNumberLabel;
    public RectTransform[] panels;

    // Use this for initialization
    void Start () {
        var _constant = BGameConstants.getInstance();
        titleLabel.text = _constant.gameName + " " + _constant.versionName;
        titleLabel2.text = _constant.gameName + " " + _constant.versionName;
        buildNumberLabel.text = "Build " + _constant.buildNumber.ToString("0000");
        this.panels.ToList().ForEach((panel) =>
        {
            panel.GetComponent<BSlideInOut>().init();
        });
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startGame()
    {
        SceneManager.LoadScene(nextSceneName);
    }


}
