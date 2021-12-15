using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullArtController : MonoBehaviour
{
    public Animator anim;
    public entityMover_01 mainController;
    public float xInput;
    public float yInput;

    public bool usePlayerInput = false;



    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
       if(usePlayerInput)
        {
            GetPlayerInput();
        }
        else
        {
            GetAIInput();
        }
        
        anim.SetFloat("Yinput", yInput);

        anim.SetFloat("Xinput", xInput);
    }

    public void GetPlayerInput()
    {
       if (Input.GetButton("Jump"))
        {
            anim.SetTrigger("Attack1");
        }

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