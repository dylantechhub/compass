using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entityMover_01 : MonoBehaviour
{
	[Header("Global options")]
	public int  moveSpeed     = 0;
	public bool tracking      = false;
	public bool avoiding      = false;
	public bool physicsMode   = false;
	public bool randomMoving  = false;
	public bool pathFollowing = false;
	public bool controlled    = false;

	[Header("Vector stats")]
	public Vector2 inputVector;
	public Vector2 runDirection;
	public Vector2 wanderingGoalPosition;

	[Header("Path following")]
	public Transform[] goalPositions;
	public float stopDistance    = 0.0f;
	public int   currentPosition = 0;
	
	[Header("Random moving")]
	public float wanderDistance        = 0.0f;
	public float stopWanderingDistance = 0.0f;
	public Vector2 normalizedWanderDirection;
	


	[Header("Rigidbody")]
	public Rigidbody2D entityRigidbody;

	[Header("Tracking")]
	public Transform transformToTrack;
	public float trackDistance = 0.0f;

	[Header("Avoiding")]
	public Transform transformToAvoid;
	public float avoidDistance;

	// too hacky, use your own script, everything in the project is using this !
	//[Header("**Animation**")]
	//public GameObject skullAnim;

	private Vector2 usersInputVector()
	{
		inputVector = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") );

		return inputVector;
	}

	private void playerController( Vector2 inputVector )
	{
		if( physicsMode == false )
		{
			kinematicMovement( inputVector );
		}
		else
		{
			physicalMovement( inputVector );
		}
	}

	private void pathFollowingLogic()
	{
		Vector2 vectorToPathGoal = ( Vector2 )goalPositions[currentPosition].position - ( Vector2 )transform.position;
		Vector2 normalizedPathDirection = vectorToPathGoal.normalized;

		transform.Translate( normalizedPathDirection * moveSpeed * Time.deltaTime );

		float distanceToGoal = vectorToPathGoal.magnitude;
		if( distanceToGoal < stopDistance )
		{
			currentPosition++;
			if( currentPosition >= goalPositions.Length )
			{
				currentPosition = 0;
			}
		}
	}

	private void trackingLogic()
	{
		Vector2 vectorToTrackObject = transformToTrack.position - transform.position;
		float distanceToTrackObject = vectorToTrackObject.magnitude;

		if( distanceToTrackObject < trackDistance )
		{
			Vector2 runDirection = vectorToTrackObject;
			runDirection = runDirection.normalized;

			transform.Translate( runDirection * moveSpeed * Time.deltaTime );
		}
	}

	private void avoidLogic()
	{
		Vector2 vectorToAvoidObject = transformToAvoid.position - transform.position;
		float distanceToAvoidObject = vectorToAvoidObject.magnitude;

		if( distanceToAvoidObject < avoidDistance )
		{
			Vector2 runDirection = vectorToAvoidObject * -1f;
			runDirection = runDirection.normalized;

			transform.Translate( runDirection * moveSpeed * Time.deltaTime  );
		}
	}

	private void findNewGoal()
	{
		wanderingGoalPosition = Random.insideUnitCircle * wanderDistance;
	}

	private void randomMovingLogic()
	{
		Vector2 vectorToGoal = wanderingGoalPosition - ( Vector2 )transform.position;
		normalizedWanderDirection = vectorToGoal.normalized;

		transform.Translate( normalizedWanderDirection * moveSpeed * Time.deltaTime );

		float distanceToWanderingGoal = vectorToGoal.magnitude;
		if( distanceToWanderingGoal < stopWanderingDistance )
		{
			findNewGoal();
		}
	}

	private void kinematicMovement( Vector2 kinematicInputVector )
	{
		transform.Translate( kinematicInputVector * moveSpeed * Time.deltaTime );
	}

	private void physicalMovement( Vector2 physicalInputVector )
	{
		entityRigidbody.AddForce( physicalInputVector * moveSpeed );
	}

	void Start()
	{
		if( randomMoving == true )
		{
			findNewGoal();
		}

		if( physicsMode == true )
		{
			entityRigidbody = GetComponent<Rigidbody2D>();
		}
	}

	void FixedUpdate()
	{
		if( controlled == true )
		{
			if( physicsMode == true )
			{
				playerController( usersInputVector() );
			}
		}
	}

	void Update()
	{
		if( controlled == true )
		{
			if( physicsMode == false )
			{
				playerController( usersInputVector() );
			}
		}

		if( randomMoving == true )
		{
			randomMovingLogic();
		}
		
		if( avoiding == true )
		{
			avoidLogic();
		}

		if( tracking == true )
		{
			trackingLogic();
		}

		if( pathFollowing == true )
		{
			pathFollowingLogic();
		}
	}
/*
	// SO HACKY!!!!!!!!!!!!!!!!!!!!!!!!!!!
	public void OnTriggerEnter2D(Collider2D collision)
	{
		SkullArtController sac = skullAnim.GetComponent<SkullArtController>();
		if (sac != null)
		{
			sac.skullIsAttacking = true;
		}
	}
	public void OnTriggerExit2D(Collider2D collision)
	{
		SkullArtController sac = skullAnim.GetComponent<SkullArtController>();
		if (sac != null)
		{
			sac.skullIsAttacking = false;
		}
	}
*/

}
