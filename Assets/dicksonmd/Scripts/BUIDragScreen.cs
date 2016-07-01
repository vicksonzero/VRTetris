using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(EventTrigger))]
public class BUIDragScreen : MonoBehaviour {

    float startX = 0;
    public float sensitivity = 0.8f;

    public Transform tetrisGameGroup;

	// Use this for initialization
	void Start ()
    {
        EventTrigger trigger = GetComponentInParent<EventTrigger>();

        // event handlers for PointerEnter
        EventTrigger.Entry entryPointerEnter = new EventTrigger.Entry();
        entryPointerEnter.eventID = EventTriggerType.PointerDown;
        entryPointerEnter.callback.AddListener((eventData) => { onPointerDown(eventData); });
        trigger.triggers.Add(entryPointerEnter);

        // event handlers for PointerExit
        EventTrigger.Entry entryPointerExit = new EventTrigger.Entry();
        entryPointerExit.eventID = EventTriggerType.Drag;
        entryPointerExit.callback.AddListener((eventData) => { onPointerDrag(eventData); });
        trigger.triggers.Add(entryPointerExit);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void onPointerDown(BaseEventData e)
    {
        Vector2 localCursor;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
                GetComponent<RectTransform>(),
                ((PointerEventData)e).position,
                ((PointerEventData)e).pressEventCamera,
                out localCursor))
        {
            return;

        }

        startX = localCursor.x;
        //Debug.Log("LocalCursor:" + localCursor);
    }

    void onPointerDrag(BaseEventData e)
    {
        Vector2 localCursor;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
                GetComponent<RectTransform>(),
                ((PointerEventData)e).position,
                ((PointerEventData)e).pressEventCamera,
                out localCursor))
        {
            return;
        }

        var xx = startX - localCursor.x;
        tetrisGameGroup.Rotate(Vector3.up, xx* sensitivity);
        startX = localCursor.x;
    }
}
