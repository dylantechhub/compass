#pragma warning disable 0108 // disables editor warning

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullTriggerPathFollowing : MonoBehaviour
{
    public GameObject trigger;
    public GameObject skull;
    public CircleCollider2D collider;

    private void Start()
    {
        collider = skull.GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        skull.GetComponent<SkullPathFollowing>().enabled = true;
        skull.GetComponent<entityMover_01>().enabled = false;
        collider.enabled = true;
        trigger.SetActive(false);
        Debug.Log("Path Following is enabled");
    }
}
