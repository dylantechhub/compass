using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerEvent : MonoBehaviour
{
    public float time = 3;
    public UnityEvent eventToCall;
    private float currentTime;
    public bool repeatEvent = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( currentTime > time)
        {
            eventToCall.Invoke();
            if (!repeatEvent)
            {
                enabled = false;
            }
            else
            {
                currentTime = 0;
            }
        }
        currentTime += Time.deltaTime;
    }
}
