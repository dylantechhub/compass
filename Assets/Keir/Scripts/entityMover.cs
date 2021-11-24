using UnityEngine;

public class entityMover : MonoBehaviour
{
	[Header("Global options")]
	public int  moveSpeed = 0;
	public bool tracking  = false;

	[Header("Stats")]
	public Vector2 userInputVector = Vector2.zero;
	public Vector2 runDirection;

	[Header("Tracking options")]
	public Transform transformToFollow;
	public float followDistance = 0.0f;

	void Update()
	{
		if( tracking )
		{
			Vector2 vectorToFollowObject = transformToFollow.position - transform.position;
			float followDistanceObject = vectorToFollowObject.magnitude;

			Debug.DrawLine( transform.position, transformToFollow.position, Color.red );

			if( followDistanceObject < followDistance )
			{
				Vector2 runDirection = vectorToFollowObject;
				runDirection = runDirection.normalized;

				transform.Translate( runDirection * moveSpeed * Time.deltaTime );
			}
		}

		else
		{
			userInputVector = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") );

			transform.Translate( userInputVector * moveSpeed * Time.deltaTime );
		}
	}
}
