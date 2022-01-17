using UnityEngine;

public class Spider_Animation_Controller : MonoBehaviour
{
	[Header("External references")]
	public Animator animator;
	public Vector2 spidersVector = Vector2.zero;
	public Vector2 playersVector = Vector2.zero;
	public float attackDistance = 5f;

	[Header("Statistics")]
	public float playerVectorMagnitude;
	public bool attacking = false;

	/* Update() is called once per frame */
	private void Update()
	{
		animator.SetFloat("moveX", spidersVector.x);
		animator.SetFloat("moveY", spidersVector.y);
		animator.SetBool("attacking", attacking);

		playerVectorMagnitude = playersVector.magnitude;

		if(playerVectorMagnitude <= attackDistance)
		{
			attacking = true;
		}
		else
		{
			attacking = false;
		}
	}
}
