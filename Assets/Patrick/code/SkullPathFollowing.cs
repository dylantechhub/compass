using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullPathFollowing : MonoBehaviour
{
    [Header("**Refrences**")]
    public GameObject player;

    [Header("**Positions**")]
    public int currentPosition = 0;
    public Vector2 position;
    public Transform[] goalPositions;
    public float stopDistance = 0.1f;
    public Vector2 normalizedDirection;
    public Vector2 playersPosition;

    [Header("**Stats**")]
    public float moveSpeed = 1f;
    public float stoppingDistance = 0.1f;
    public float cooldownTime;
    public float timer;
    public bool timerActive = false;
    public bool chasingPlayer = false;

    [Header("**Animation**")]
    public GameObject skullAnim;

    // Update is called once per frame
    void Update()
    {
        // Current Skull position
        position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        // Current Players position
        playersPosition = new Vector2(player.transform.position.x, player.transform.position.y);

        // When skull reaches player it will avoid it for a cooldown time
        // Checks if the skull is chasing the player or not
        if (chasingPlayer && stoppingDistance >= Vector3.Distance(playersPosition, position))
        {
            // Turn on the timer so that avoiding activates for "cooldownTime"
            timer = cooldownTime;
            timerActive = true;

            chasingPlayer = false;
        }

        // Cooldown timers
        if (timerActive == true)
        {
            // Debug.Log("Timer is active");
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timerActive = false;
        }

        // Updates the method according to state
        if (chasingPlayer)
        {
            MoveTowardsPlayer();
        }
        else
        {
            AvoidingPlayer();
        }

    }

    // When chasing is false run
    public void AvoidingPlayer()
    {
        if (timerActive == true)
        {
            // avoid 
            Vector2 vectorToGoal = (Vector2)goalPositions[currentPosition].position - (Vector2)transform.position;
            normalizedDirection = vectorToGoal.normalized;
            // move away the goal position

            Debug.DrawLine(transform.position, (Vector2)goalPositions[currentPosition].position, Color.red);

            transform.Translate(normalizedDirection * moveSpeed * -1f * Time.deltaTime);
        }
        else
        {
            chasingPlayer = true;
        }
    }

    // When chasing is true run
    public void MoveTowardsPlayer()
    {
        // If skulls position is not same as player it will go towards it
        if (position != playersPosition && timerActive == false)
        {

            Vector2 vectorToGoal = (Vector2)goalPositions[currentPosition].position - (Vector2)transform.position;
            normalizedDirection = vectorToGoal.normalized;
            // move towards the goal position

            Debug.DrawLine(transform.position, (Vector2)goalPositions[currentPosition].position, Color.green);

            transform.Translate(normalizedDirection * moveSpeed * Time.deltaTime);
        }

    }

    // Attack animation
    public void OnTriggerEnter2D(Collider2D collision)
    {
        skullAnim.GetComponent<SkullArtController>().skullIsAttacking = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        skullAnim.GetComponent<SkullArtController>().skullIsAttacking = false;
    }

}
