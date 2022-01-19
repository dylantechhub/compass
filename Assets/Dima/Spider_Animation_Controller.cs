using UnityEngine;

public class Spider_Animation_Controller : MonoBehaviour
{
	[Header("External references")]
	public Animator animator;
	public entityMover_01 mover;
	public Transform player;
	public Vector2 spidersVector = Vector2.zero;
	
	public float attackDistance = 5f;
	public float currentDistance = 0;
	[Header("Statistics")]
	
	public bool attacking = false;

	/* Update() is called once per frame */
	private void Update()
	{
		spidersVector = mover.runDirection;

		animator.SetFloat("xIn", spidersVector.x);
		animator.SetFloat("yIn", spidersVector.y);
		animator.SetBool("attacking", attacking);


		currentDistance = Vector3.Distance(mover.transform.position, player.position);
		

		if(currentDistance<= attackDistance)
		{
			attacking = true;
		}
		else
		{
			attacking = false;
		}
	}
}
