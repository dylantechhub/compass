using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    // Do this with kinematics for now. 
    //public Rigidbody2D rigid;
    public float moveSpeed = 1f;

    public Vector2 goalPosition;
    public float wanderDistance = 1f;
    public float stopDistance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        FindNewGoal();
    }

    private void FindNewGoal()
    {
        goalPosition = Random.insideUnitCircle * wanderDistance;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vectorToGoal = goalPosition - (Vector2)transform.position;
        Vector2 normalizedDirection = vectorToGoal.normalized;
        // move towards the goal position    

        Debug.DrawLine(transform.position, goalPosition, Color.green);

        transform.Translate(normalizedDirection * moveSpeed * Time.deltaTime);

        float distanceToGoal = vectorToGoal.magnitude;
        if(distanceToGoal < stopDistance)
        {
            // Reached Goal and start again. 
            FindNewGoal();
        }
    }
}
