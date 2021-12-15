using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobartcontroller : MonoBehaviour
{

    public Animator anim;

    public PathFollowing mainControl;

    public float xInput; 
    public float yInput; 


    // Start is called before the first frame update
    void Start()


    { //this is for testing for now

        anim.SetBool("SlimeIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump")){
            anim.SetTrigger("SlimeAppear");
        }

        Vector2 localVector = mainControl.normalizedDirection;
        xInput = localVector.x;
        yInput = localVector.y;

    } 

    public void Attack()
    {
        
    }
}
