using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorArtController : MonoBehaviour
{
    // Variables
    public Animator anim; // reference to the animation controller
    public float xInput;
    public float yInput;
    public bool isWalking = false;

    public bool usePlayerInput = false;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("IsWalking", true);
        anim.SetTrigger("Taunt1");
    }

    // Update is called once per frame
    void Update()
    {



        if(usePlayerInput)
        {
            GetPlayerInput();
        }else
        {
            GetAIInput();
        }

        // Used by both the player and AI
        if (yInput == 0 && xInput == 0)
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }

        anim.SetBool("IsWalking", isWalking);
        anim.SetFloat("xInput", xInput);
        anim.SetFloat("yInput", yInput);
    }

    public void GetPlayerInput(){
        if (Input.GetButton("Jump")) {
            anim.SetTrigger("Attack1");
        }

        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");   
    }

    public void GetAIInput(){
        // [ ] To do tomorrow
        // get a ref to the parent control script
        // get the vector that ccorresponds to the direction we are moving
        // assign those to the xInput and yInput values
    }

}
