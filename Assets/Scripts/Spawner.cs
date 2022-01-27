using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timer = 0;
    public float spawnTime = 2f;

    public Transform thingToSpawn;
    public float radius = 5;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnTime)
        {
            Spawn();
            timer = 0;

        }
    }

    
    // Creates a thing
    public void Spawn()
    {
        Vector3 spawnPosition = Random.insideUnitCircle * radius;
        spawnPosition = transform.position + spawnPosition;
        Transform spwanedThing = Instantiate(thingToSpawn, spawnPosition, transform.rotation);
    }
}
