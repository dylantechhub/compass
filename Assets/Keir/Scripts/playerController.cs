using UnityEngine;

public class playerController : MonoBehaviour
{
	[Header("Options")]
	public int  movementForce = 0;
	public bool allowAccess   = false;

	[Header("Stats")]
	public Vector2 userInputVector = Vector2.zero;

	/* update is called once per frame */
	void Update()
	{
		/* store user input in the vector initialized earlier */
		userInputVector = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") );

		/*  move the player along player specified axes with specified force */
		Vector2 translation = userInputVector * movementForce * Time.deltaTime;
		transform.Translate( translation );
	}

	/* allows other scripts to access this one through Unity Events */
	public bool playerControllerScript()
	{
		return allowAccess;
	}
}
