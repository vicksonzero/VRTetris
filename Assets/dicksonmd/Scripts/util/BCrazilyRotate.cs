using UnityEngine;
using System.Collections;
using System.Linq;

public class BCrazilyRotate : MonoBehaviour {

    [Tooltip("x,y,z rotation")]
    public float speedsMin = 0;

    [Tooltip("x,y,z rotation")]
    public float speedsMax = 0;

    public float speed = 0;

    // Use this for initialization
    void Start () {
        speed = Random.Range(speedsMin, speedsMax);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(this.transform.up, speed);
	}
}
