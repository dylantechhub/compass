using UnityEngine;

public class GargoyleArtController : MonoBehaviour
{
    [Header ("*Refrences*")]

    public Animator animator;
    public Transform playerPosition;
    public Transform gargoylePostion;
    public GargoylePathFollowing pathFollowing;

    [Header("*Variables*")]

    public float horizInput;
    public float vertInput;
    public bool isWalking;
    public bool isAttacking;

    [Header("*Timer Info*")]

    public float timer;
    public float timeBetweenAttacks;

    // Update is called once per frame
    void Update()
    {
        // Timer and a reference to the path following vector
        timer += Time.deltaTime;
        Vector2 localVector = pathFollowing.normalizedDirection;

        // Player walking bool
        if (horizInput == 0 && vertInput == 0)
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }

        // Timer for fire breath enables attack and disables if statement is false
        if (timer >= timeBetweenAttacks && pathFollowing.enabled == true)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }

        // Left & Right animations
        if (playerPosition.position.x < gargoylePostion.position.x && pathFollowing.enabled == true)
        {
            animator.SetBool("Walking Left", true);
            animator.SetBool("Walking Right", false);
            animator.SetBool("Walking Forward", false);
        }
        else if (playerPosition.position.x == gargoylePostion.position.x && pathFollowing.enabled == true)
        {
            animator.SetBool("Walking Forward", true);
            animator.SetBool("Walking Left", false);
            animator.SetBool("Walking Right", false);
        }
        else if (playerPosition.position.x > gargoylePostion.position.x && pathFollowing.enabled == true)
        {
            animator.SetBool("Walking Right", true);
            animator.SetBool("Walking Left", false);
            animator.SetBool("Walking Forward", false);
        }

        // Attack Listener
        if (isAttacking)
        {
            Attacking();
        }
        
        // Input Listener
        if (Input.GetButton("Jump"))
        {
            animator.SetTrigger("Player Input");
        }

        // Player Input
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        // Input parameters
        animator.SetFloat("xInput", horizInput);
        animator.SetFloat("yInput", vertInput);
    }

    public void Attacking()
    {
        animator.SetTrigger("Fire Attack");
        Debug.Log("Fire Attack");
        timer = 0f;
    }

}
