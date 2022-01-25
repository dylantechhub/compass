using UnityEngine;

public class ArtichokeAnimationController : MonoBehaviour
{
	[Header("External references")]
	public Animator animator;
	public Transform player;
	public Transform artichokeHeart;

	[Header("Variables")]
	private Vector3 playerPosition;
	private Vector3 artichokePosition;
	private float distanceFromArtichokeToPlayer = 0;
	public string animatorBooleanVariable;

	//public float playerVectorMagnitude;
	//public float artichokeVectorMagnitude;
	public float distanceToStayClosed;
	public float timeToStayOpen;
	private float timer;
	private bool timerStopped = true;
	private bool isOpened;

	private void Timer()
	{
		if(timerStopped == false & distanceFromArtichokeToPlayer >= distanceToStayClosed)
		{
			timer += Time.deltaTime;
			if(timer >= timeToStayOpen)
			{
				timerStopped = true;
			}
		}

		if(timerStopped & animator != null & distanceFromArtichokeToPlayer >= distanceToStayClosed)
		{
			animator.SetBool(animatorBooleanVariable, true);
			isOpened = true;
		}
	}

	private void PlayerDistanceFromArtichoke()
	{
		playerPosition = player.position;
		artichokePosition = artichokeHeart.position;

		Vector3 vectorFromArtichokeToPlayer = playerPosition - artichokePosition; // actually a vector now
		float distanceFromArtichokeToPlayer = vectorFromArtichokeToPlayer.magnitude;

		if(distanceFromArtichokeToPlayer >= distanceToStayClosed & timer <= timeToStayOpen & animator != null)
		{
			animator.SetBool(animatorBooleanVariable, true);
			isOpened = true;
			timerStopped = false;
		}
		else if(animator != null)
		{
			animator.SetBool(animatorBooleanVariable, false);
			isOpened = false;
		}
	}

	/* Start() is called once before the first frame update */
	private void Start()
	{
		if (animator == null)
		{
			Debug.Log("Failed to retrieve animator reference!");
		}

		if (player == null)
		{
			Debug.Log("Failed to retrieve player reference!");
		}
		
	}

	/* Update() is called once per frame update */
	private void Update()
	{
		PlayerDistanceFromArtichoke();
		Timer();
	}
}