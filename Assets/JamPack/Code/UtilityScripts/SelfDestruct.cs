using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A simple utility script that just destroys the current gameobject
public class SelfDestruct : MonoBehaviour {

    public bool autoDestructOnStart = false;
    public float deathAtThisTime;

    public Transform spawnOnDestruct;
    public bool spawnOnDestructToggle = false;
    public float currentTimer = 0;

	// Use this for initialization
	void Start () {
        if( autoDestructOnStart && !spawnOnDestructToggle)
        {
            Destroy(gameObject, deathAtThisTime);
        }
    }

    private void Update()
    {
        currentTimer += Time.deltaTime;
        if( currentTimer > deathAtThisTime && spawnOnDestruct != null) {

            Instantiate<Transform>(spawnOnDestruct, transform.position, transform.rotation);
            Destroy(gameObject, 0);
        }
    }

    // Call this to destroy self from script or events
    public void Destruct(float newTimer){
        Destroy(gameObject, newTimer);
    
    }

}
