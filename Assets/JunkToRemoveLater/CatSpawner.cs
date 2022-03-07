using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public Transform player;
    public entityMover_01 prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Spawn()
    {
        entityMover_01 spawned = Instantiate(prefab, transform.position, transform.rotation);
        spawned.transformToTrack = player;


    }
}
