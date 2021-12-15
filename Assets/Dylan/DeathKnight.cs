using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathKnight : MonoBehaviour
{
    public Transform player;

    public UnityEvent attack1;
    public Rigidbody2D rigid;
    public Transform playerRef;

    public float attackDistance = 1f;
    public float moveForce = 5f;

    public float attackCooldownTimer = 0;
    public float attackCooldownLimit = 1f;

    public DeathKnightArtController art;

    Vector2 toPlayer;

    // Update is called once per frame
    void Update()
    {
        toPlayer = playerRef.position - transform.position;
        Debug.DrawRay(transform.position, toPlayer, Color.yellow);

        if(toPlayer.magnitude < attackDistance && attackCooldownLimit < attackCooldownTimer)
        {
            attack1.Invoke();

            art.PlayAttack1();
            attackCooldownTimer = 0;
            
        }
        attackCooldownTimer += Time.deltaTime;


        // Testing!!! 
        if (Input.GetKeyDown(KeyCode.P)){
            Attack();
        }
    }

    public void FixedUpdate()
    {
        Vector2 directionToPlayer = toPlayer.normalized;
        rigid.AddForce(directionToPlayer * moveForce);
    }

    public void Attack()
    {


    }
}
