using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullArtController : MonoBehaviour
{
    [Header("**Refreneces**")]
    public Animator anim;
    public entityMover_01 mainController;
    public Transform skullPosition;
    public Transform playerPosition;

    [Header("**Stats**")]
    public float xInput;
    public float yInput;
    public bool usePlayerInput = false;
    public bool skullIsAttacking = false;

    void Start()
    {
     //   usePlayerInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Checking if using ai or player input
       if(usePlayerInput)
        {
            GetPlayerInput();
        }
        else
        {
            GetAIInput();
        }

       // Changes if skull is attacking, then changes animation
        if (skullIsAttacking)
        {
            anim.SetTrigger("Attack1");
        }
        else
        {
            anim.SetBool("Attack1", false);
        }

        // Changing animation depending on direction from player
        if (playerPosition.position.x < skullPosition.position.x)
        {
            anim.SetBool("leftView", true);
            anim.SetBool("WalkRight", false);
        }
        else if (playerPosition.position.x > skullPosition.position.x)
        {
            anim.SetBool("WalkRight", true);
            anim.SetBool("leftView", false);
        }

        anim.SetFloat("Yinput", yInput);
        anim.SetFloat("Xinput", xInput);
    }

    public void GetPlayerInput()
    {
        xInput = Input.GetAxis("Horizontal");
        
        yInput = Input.GetAxis("Vertical");
    }

    public void GetAIInput()
    {
        Vector2 localVector = mainController.normalizedWanderDirection; 
        xInput = localVector.x;
        yInput = localVector.y;    
    }

}