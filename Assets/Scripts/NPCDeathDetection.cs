using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCDeathDetection : MonoBehaviour
{
	[Header("Scene references")]
	public string entranceScene = "EntranceScene";
	public string skullScene = "Scene1-Skull";
	public string catScene = "Scene2-Cat";
	public string gargoyleScene = "Scene3-Gargoyle";
	public string slimeScene = "Scene4-Shlime";
	public string spiderScene = "Scene5-Spider";
	public string plantMonsterScene = "Scene6-PlantMonster";
	public string deathNightScene = "Scene7-DeathKnight Boss";

	[Header("Boolean death checkboxes")]
	private bool skullDead;
	private bool catDead;
	private bool gargoyleDead;
	private bool slimeDead;
	private bool spiderDead;
	private bool plantMonsterDead;
	private bool deathNightDead;

	private PortalReference portalReference;
	private string currentScene;

	private void Start()
	{
		DontDestroyOnLoad(gameObject);
	}

	void OnLevelWasLoaded()
	{
		currentScene = SceneManager.GetActiveScene().name;
		GameObject npc = GameObject.FindWithTag("NPC");

		if(currentScene == entranceScene)
		{
			portalReference = FindObjectOfType<PortalReference>();
		}

		if(npc != null)
		{
			Health npcHealth = npc.GetComponentInChildren<Health>();

			if(npcHealth != null)
			{
				npcHealth.killedEvent.AddListener(NPCKilled);
			}
			else
			{
				Debug.LogError("Couldn't find NPC Health!");
			}
		}
		else if(currentScene != entranceScene)
		{
			Debug.LogError("Couldn't find NPC in scene!");
		}

		if(currentScene == entranceScene)
		{
			PortalDisabler();
		}
	}

	private void PortalDisabler()
	{
		if(skullDead)
		{
			portalReference.skullPortal.SetActive(false);
		}
		
		if(catDead)
		{
			portalReference.catPortal.SetActive(false);
		}

		if(gargoyleDead)
		{
			portalReference.gargoylePortal.SetActive(false);
		}

		if(slimeDead)
		{
			portalReference.slimePortal.SetActive(false);
		}

		if(spiderDead)
		{
			portalReference.spiderPortal.SetActive(false);
		}

		if(plantMonsterDead)
		{
			portalReference.plantMonsterPortal.SetActive(false);
		}

		if(deathNightDead)
		{
			portalReference.deathNightPortal.SetActive(false);
		}
	}

	private void NPCKilled()
	{
		if(currentScene.Equals(skullScene)) 
		{
			skullDead = true;
			Debug.Log("Skull died!");
		}
		else if(currentScene.Equals(catScene))
		{
			catDead = true;
			Debug.Log("Cat died!");
		}
		else if(currentScene.Equals(gargoyleScene)) 
		{
			gargoyleDead = true;
			Debug.Log("Gargoyle died!");
		}
		else if(currentScene.Equals(slimeScene))
		{
			slimeDead = true;
			Debug.Log("Slime died!");
		}
		else if(currentScene.Equals(spiderScene))
		{
			spiderDead = true;
			Debug.Log("Spider died!");
		}
		else if(currentScene.Equals(plantMonsterScene))
		{
			plantMonsterDead = true;
			Debug.Log("Plant monster died!");
		} 
		else if(currentScene.Equals(deathNightScene))
		{
			deathNightDead = true;
			Debug.Log("Death night died!");
		}
		else
		{
			Debug.LogError("NPCKilled() in NPCDeathDetection has been called but the scene could not be found.\n" +
			"Are the scene names correct?");
		}
	}
}
