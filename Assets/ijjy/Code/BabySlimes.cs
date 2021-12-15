using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySlimes : MonoBehaviour
{
    public GameObject babySlimePrefab;
    public GameObject slime;
    public Vector2 slimeLocation;

    private void Update()
    {
        slimeLocation = slime.transform.position;
    }

    public void SpawnSlimeBabies()
    { 
        Instantiate(babySlimePrefab, slimeLocation , Quaternion.identity);
    }

}
