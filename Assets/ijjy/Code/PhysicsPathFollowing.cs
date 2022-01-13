using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPathFollowing : MonoBehaviour
{
    // Do this with kinematics for now. 
    public Rigidbody2D rigid;
    public float moveSpeed = 1f;

    public int currentPosition = 0;
    public Transform[] goalPositions;
    public float stopDistance = 0.1f;
    public Vector2 normalizedDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void NextPath()
    {
        currentPosition++;
        if(currentPosition >= goalPositions.Length)
        {
            currentPosition = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 vectorToGoal = (Vector2)goalPositions[currentPosition].position - (Vector2)transform.position;
         normalizedDirection = vectorToGoal.normalized;
        // move towards the goal position    

        Debug.DrawLine(transform.position, (Vector2)goalPositions[currentPosition].position, Color.green);

        rigid.AddForce(normalizedDirection * moveSpeed);

        float distanceToGoal = vectorToGoal.magnitude;
        if(distanceToGoal < stopDistance)
        {
            // Reached Goal and start again. 
            NextPath();
        }
    }
}
