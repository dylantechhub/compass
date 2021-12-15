using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlimeTrigger : MonoBehaviour
{
    public UnityEvent babySlimesBorn;

    private void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            babySlimesBorn.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        babySlimesBorn.Invoke();
    }
}
