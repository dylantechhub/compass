using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public bool isAttacking = false;
    public Animator swordAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetButton("Fire1")){
            isAttacking = true;
        }else{
            isAttacking = false;
        }
        swordAnim.SetBool("IsAttacking", isAttacking);
    }
}
