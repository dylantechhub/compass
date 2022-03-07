using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileLauncher : MonoBehaviour
{

    public Rigidbody2D shotPrefab;
    public float speed;
    private Vector2 input;
    private bool attackInput = false;

    public float cooldown = 1.5f;
    private float currentTimer = 0;



    // Start is called before the first frame update
    void Start()
    {
        currentTimer = cooldown; // so we cna shoot immediately 
    }

    private void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        attackInput = Input.GetButtonDown("Fire1"); 

        currentTimer += Time.deltaTime;

        if (attackInput)
        {
            Debug.Log("Button Pressed");
        }

        if(attackInput && currentTimer > cooldown && input.magnitude > 0.2f)
        {
            Shoot ();
            currentTimer = 0;
            Debug.Log("Shooting");
        }
    }
     
    // Update is called once per frame
    void Shoot()
    {
        Rigidbody2D rigid = Instantiate<Rigidbody2D>(shotPrefab, transform.position, transform.rotation);
        rigid.velocity = input.normalized * speed;
    }
}
