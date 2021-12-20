using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlimeTrigger : MonoBehaviour
{
    // Temperaorary variables for a timer to spawn baby slimes
    public float timer;
    public float timeBetweenSpawn = 10f;
    // Can be deleted once slimes spawn can trigger on death

    public UnityEvent babySlimesBorn;

    private void Update()
    {
        timer += Time.deltaTime;

        // Change to when slime dies trigger babySlimesBorn when health script is ready
        if (timer >= timeBetweenSpawn)
        {
            babySlimesBorn.Invoke();
            timer = 0;
        }
    }
}
