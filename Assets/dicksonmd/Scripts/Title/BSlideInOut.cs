using UnityEngine;
using System.Collections;

public class BSlideInOut : MonoBehaviour {

    private enum AnimTypes { IN, OUT, STOP};
    private AnimTypes animType = AnimTypes.STOP;

    private Vector3 destPosition;

    private RectTransform rt;

    public Vector3 inPosition;
    public Vector3 startPosition;
    public Vector3 outPosition;

    private float animStartTime;
    private float animTime = 1f;

    public void init()
    {
        this.rt = this.GetComponent<RectTransform>();
        this.destPosition = this.rt.localPosition;
        this.startPosition = this.rt.localPosition;
        this.inPosition = this.rt.localPosition + new Vector3(1920, 0, 0);
        this.outPosition = this.rt.localPosition - new Vector3(1920, 0, 0);
    }

    void Update()
    {
        if(this.animType != AnimTypes.STOP)
        {
            var progressPercent = (Time.time - this.animStartTime) / this.animTime;
            this.rt.localPosition = Vector3.Lerp(this.rt.localPosition, this.destPosition, progressPercent);

            if(progressPercent>=1.0f)
            {
                if(this.animType == AnimTypes.OUT) this.gameObject.SetActive(true);
                this.animType = AnimTypes.STOP;
            }
        }
    }

    public void slideOut(float time)
    {
        this.animTime = time;
        this.animStartTime = Time.time;
        this.animType = AnimTypes.OUT;
        this.destPosition = this.outPosition;
    }

    public void slideIn(float time)
    {
        this.gameObject.SetActive(true);
        this.animTime = time;
        this.animStartTime = Time.time;
        this.rt.localPosition = this.inPosition;
        this.animType = AnimTypes.OUT;
        this.destPosition = this.startPosition;
    }
}
