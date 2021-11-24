using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D Fired by " + collision.gameObject.name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D Fired by " + collision.gameObject.name);
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OnTriggerStay2D Fired by " + collision.gameObject.name);
    }
    */

}
