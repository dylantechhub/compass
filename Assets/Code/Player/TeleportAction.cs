using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAction : MonoBehaviour
{
    [Header("Input")]
    public Vector2 inputDirection;
    public float pressTime;
    public bool buttonIsHeld = false; 

    [Header("Settings")]
    public float maxPressTime = 2f;
    public float maxDistance = 3f;

    // Update is called once per frame
    void Update()
    {
        inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // hold button down
        if (Input.GetButtonDown("Jump"))
        {
            buttonIsHeld = true;
        }

        if (Input.GetButton("Jump"))
        {
            pressTime += Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump"))
        {
            buttonIsHeld = false;
            Teleport();
        }

    }

    private void Teleport()
    {
        Debug.Log("Teleport");
        //pressTime // input value 
        //    maxPressTime // max time
        // pressTime must be equal or less then maxPressTime
        // Distance
        pressTime = Mathf.Min(pressTime, maxPressTime);

        float remappedPressTime = pressTime / maxPressTime;
        float teleportDistance = maxDistance * remappedPressTime;

        // Direction
        Vector2 normDirection = inputDirection.normalized;

        Vector2 vectToTeleport = teleportDistance * normDirection;

        transform.Translate(vectToTeleport);

        // what happens if the input vector is 0
    }
}
