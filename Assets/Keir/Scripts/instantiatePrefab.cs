using UnityEngine;

public class instantiatePrefab : MonoBehaviour
{
	[Header("Prefab to instantiate")]
	public GameObject prefab;

	[Header("Options")]
	public bool useVector = false;
	public Vector3 vector = Vector3.zero;

	/* start is called before the first frame update */
	void Start()
	{
		/* if useVector is true, use the vector for instantiation
		 * if useVector is false, use the transform for instantiation
		 */
		if( useVector )
		{
			Instantiate( prefab, vector, Quaternion.identity );
		}

		else
		{
			Instantiate( prefab, transform.position, transform.rotation );
		}
	}
}
