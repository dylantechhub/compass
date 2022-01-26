using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputToAnimator : MonoBehaviour
{
    [Header("***Walk Input Animation***")]
    public Animator anim;
    public Vector2 input;

    [Header ("***Attack Input Animation***")]
    public bool isAttacking = false;
    public bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        // Grabing walking input
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        anim.SetFloat("xInput", input.x);
        anim.SetFloat("yInput", input.y);

        // When Triggered will make attacking true then activate animation
        if (Input.GetButton("Fire1"))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }

        anim.SetBool("IsDead", isDead);
        anim.SetBool("IsAttacking", isAttacking);
    }

    public void PlayerDied()
    {
        isDead = true;
    }
}
