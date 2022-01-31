using UnityEngine;

public class PortalReference : MonoBehaviour
{
	[Header("Portal references")]
	public GameObject skullPortal;
	public GameObject catPortal;
	public GameObject gargoylePortal;
	public GameObject slimePortal;
	public GameObject spiderPortal;
	public GameObject plantMonsterPortal;
	public GameObject deathNightPortal;

	private void Start()
	{
		if(skullPortal == null)
		{
			Debug.LogWarning("Skull portal reference not found on PortalReference script!");
		}

		if(catPortal == null)
		{
			Debug.LogWarning("Cat portal reference not found on PortalReference script!");
		}

		if(gargoylePortal == null)
		{
			Debug.LogWarning("Gargoygle portal reference not found on PortalReference script!");
		}

		if (slimePortal == null)
		{
			Debug.LogWarning("Slime portal reference not found on PortalReference script!");
		}

		if(spiderPortal == null)
		{
			Debug.LogWarning("Spider portal reference not found on PortalReference script!");
		}

		if(plantMonsterPortal == null)
		{
			Debug.LogWarning("Plant monster portal reference not found on PortalReference script!");
		}

		if(deathNightPortal == null)
		{
			Debug.LogWarning("Death night portal reference not found on PortalReference script!");
		}
	}
}
