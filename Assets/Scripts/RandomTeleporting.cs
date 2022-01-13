/* player teleporter script written by keir yurkiw for the tech hub course
 * this is script is unclicensed
 *
 * all time values are in seconds
 *
 * the teleport vector is added to the random vector. keep this in mind when
 * setting the teleport distance.
 */ 

using UnityEngine;

public class RandomTeleporting : MonoBehaviour
{
	[Header("Prefabs")]
	public Transform objectTransform;

	[Header("Settings")]
	public float maxHoldTime = 5.0f;
	public float teleportDistanceMultiple = 1.0f; /* must be a value > 0 */
	public float maxTeleportDistance = 10.0f;
	public float cooldown = 3.0f;
	public float randomnessRangeMin = 0.0f; /* randomness range refers to the random teleport vector */
	public float randomnessRangeMax = 5.0f;
	public bool randomTeleport = true;

	[Header("Statistics")] /* these values should not be manually changed */
	public Vector2 teleportVector = Vector2.zero;
	public Vector2 randomVector = Vector2.zero;
	public Vector2 userInputVector = Vector2.zero;
	public float teleportDistance = 0.0f;
	public float nonNormalizedTeleportDistance = 0.0f;
	public float nonNormalizedHoldTime = 0.0f;
	public float holdTime = 0.0f;
	public float cooldownTimer = 0.0f;
	public bool buttonHeld = false;
	public bool cooldownActive = false;

	public void CooldownLogic()
	{
		if( cooldownTimer >= 0 )
		{
			cooldownActive = true;
		}
		else
		{
			cooldownActive = false;
		}

		if( cooldownActive )
		{
			cooldownTimer -= Time.deltaTime;
		}
	}

	public void TeleportDistance()
	{
		nonNormalizedTeleportDistance = holdTime * teleportDistanceMultiple;
		teleportDistance = Mathf.Min( maxTeleportDistance, nonNormalizedTeleportDistance );
	}

	public void TeleportVector()
	{
		teleportVector = userInputVector * teleportDistance;
	}

	public void RandomVector()
	{
		if( randomTeleport )
		{
			randomVector = new Vector2( Random.Range( randomnessRangeMin, randomnessRangeMax ), Random.Range( randomnessRangeMin, randomnessRangeMax ) );
			teleportVector += randomVector;
		}
	}

	public void Teleport()
	{
		transform.Translate( teleportVector );
		cooldownActive = true;
		cooldownTimer = cooldown;
	}

	public void UserInputVector()
	{
		userInputVector = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") );
	}

	public void HoldTime()
	{
		if( Input.GetButtonUp("Jump") && !cooldownActive )
		{
			Teleport();
		}

		if( Input.GetButton("Jump") && !cooldownActive )
		{
			nonNormalizedHoldTime += Time.deltaTime;
			holdTime = Mathf.Min( maxHoldTime, nonNormalizedHoldTime );
			buttonHeld = true;
		}
		else
		{
			holdTime = 0.0f;
			nonNormalizedHoldTime = 0.0f;
			buttonHeld = false;
		}
	}

	void Update() /* Update() is called every frame */
	{
		HoldTime();
		UserInputVector();
		TeleportDistance();
		TeleportVector();
		CooldownLogic();
		RandomVector();
	}
}
