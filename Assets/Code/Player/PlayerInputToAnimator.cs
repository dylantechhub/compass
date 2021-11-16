using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputToAnimator : MonoBehaviour
{

    public Animator anim;
    public Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        anim.SetFloat("xInput", input.x);
        anim.SetFloat("yInput", input.y);
    }
}
