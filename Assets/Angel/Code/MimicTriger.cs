using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicTriger : MonoBehaviour
{
    public GameObject mimic;
    public GameObject gargoyle;
    public CapsuleCollider2D collider;

    private void Start()
    {
        collider = gargoyle.GetComponent<CapsuleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gargoyle.GetComponent<GargoylePathFollowing>().enabled = true;
        collider.enabled = true;
        mimic.SetActive(false);
        Debug.Log("Mimic Starts");
    }
}
