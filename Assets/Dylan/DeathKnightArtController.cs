using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathKnightArtController : MonoBehaviour
{
    public Animator anim;
    public DeathKnight referenceToMainScript;
    public Rigidbody2D attack1Rigid;

    public float walkingThreshold = 1f;

    public bool isWalking; // not needed, just for demonstrations

    // Start is called before the first frame update
    void Start()
    {
        referenceToMainScript.attack1.AddListener(PlayAttack1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = attack1Rigid.velocity;

        if( velocity.magnitude > walkingThreshold)
        {
            isWalking = true;
            anim.SetBool("IsWalking", true);
            anim.SetFloat("Name", 1.0f);
            anim.SetTrigger("Name");

        }
        else
        {
            isWalking = false;
            anim.SetBool("IsWalking", false);
        }

       
    }

    public void PlayAttack1()
    {
        anim.SetTrigger("Attack1");
    }

    public void Attack1()
    {
        anim.SetTrigger("Attack1");
    }
}
