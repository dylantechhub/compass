using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileLauncher : MonoBehaviour
{

    public Rigidbody2D shotPrefab;
    public float speed;
    private Vector2 input;
    private bool attackInput = false;

    private float cooldown = 2;
    private float currentTimer = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        attackInput = Input.GetButtonDown("Fire1"); 

        currentTimer += Time.deltaTime;

        if(attackInput && currentTimer > cooldown && input.magnitude > 0.5f)
        {
            Shoot ();
            currentTimer = 0;
        }
    }
     
    // Update is called once per frame
    void Shoot()
    {
        Rigidbody2D rigid = Instantiate<Rigidbody2D>(shotPrefab, transform.position, transform.rotation);
        rigid.velocity = input.normalized * speed;
    }
}
