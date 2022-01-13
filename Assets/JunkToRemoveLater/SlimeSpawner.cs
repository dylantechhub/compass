using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public Transform player;
    public BabySlimes slimePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Spawn()
    {
     //   Transform t = Instantiate(slimePrefab, transform.position, transform.rotation);
     //   BabySlimes slime = t.GetComponent<BabySlimes>();
    //    slime.playerRef = player;

     //   BabySlimes t = Instantiate<BabySlimes>(slimePrefab, transform.position, transform.rotation);
        

    }
}
