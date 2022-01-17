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
    public bool usePlayerInput = false;

    [Header("*Timer Info*")]

    public float timer;
    public float timeBetweenAttacks;

    // Start is called before the first frame update
    void Start()
    {
		if (usePlayerInput)
		{
            Debug.Log("Using player input!");
		}
        else
		{
            Debug.Log("Using AI input!");
		}
    }

    // Update is called once per frame
    void Update()
    {
        // Timer and a reference to the path following vector
        timer += Time.deltaTime;
        Vector2 localVector = pathFollowing.normalizedDirection;

        // Player input or AI input
        if (usePlayerInput)
        {
            GetPlayerInput();
        }
        else
        {
            GetAIInput();
        }

        // Player walking bool
        if (horizInput == 0 && vertInput == 0)
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }

        // Left & Right animations
        if (playerPosition.position.x < gargoylePostion.position.x && pathFollowing.enabled == true)
        {
            animator.SetBool("Walking Left", true);
            animator.SetBool("Walking Right", false);
            animator.SetBool("Walking Forward", false);
            // Debug.Log("walking left now");
        }
        else if (playerPosition.position.x == gargoylePostion.position.x && pathFollowing.enabled == true)
        {
            animator.SetBool("Walking Forward", true);
            animator.SetBool("Walking Left", false);
            animator.SetBool("Walking Right", false);
            // Debug.Log("walking forward now");
        }
        else if (playerPosition.position.x > gargoylePostion.position.x && pathFollowing.enabled == true)
        {
            animator.SetBool("Walking Right", true);
            animator.SetBool("Walking Left", false);
            animator.SetBool("Walking Forward", false);
            // Debug.Log("walking right now");

        }

        // Timer for fire breath
        if (timer >= timeBetweenAttacks && pathFollowing.enabled == true)
        {
            animator.SetTrigger("Fire Attack");
            timer = 0f;
        }

        // Input parameters
        animator.SetFloat("xInput", horizInput);
        animator.SetFloat("yInput", vertInput);
    }

    public void GetPlayerInput()
    {
        if (Input.GetButton("Jump"))
        {
            animator.SetTrigger("Player Input");
        }

        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
    }

    public void GetAIInput()
    {
        // Get reference to control script, and the vector that coresponds to the direction we are moving
        Vector2 localVector = pathFollowing.normalizedDirection;

        //assign those to the x and y input values
        horizInput = localVector.x;
        vertInput = localVector.y;
    }


}
