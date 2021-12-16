using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySlimes : MonoBehaviour
{
    public Transform babySlime;
    public Transform player;

    public float radius;

    public void SpawnSlimeBabies()
    {
        Vector3 spawnPosition = Random.insideUnitCircle * radius;
        spawnPosition = transform.position + spawnPosition;
        Transform spwanedThing = Instantiate(babySlime, spawnPosition, transform.rotation);
        PhysicsPathFollowing physicsPF = spwanedThing.GetComponent<PhysicsPathFollowing>();
        physicsPF.goalPositions[0] = player.transform;
    }

}
