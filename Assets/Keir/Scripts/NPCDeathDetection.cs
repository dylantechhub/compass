using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NPCDeathDetection : MonoBehaviour
{
	
	[Header("NPC death detection")]
	private bool skullDead = false;
	private bool catDead = false;
	private bool gargoyleDead = false;
	private bool slimeDead = false;
	private bool spiderDead = false;
	private bool plantMonsterDead = false;
	private bool deathNightDead = false;

    private PortalReference portalRef;
    private string currentScene;

	/* NPC death functions to be called by Unity Events */
	public void SkullDeath()
	{
		skullDead = true;
		Debug.Log("Skull died!");
	}

	public void CatDeath()
	{
		catDead = true;
		Debug.Log("Cat died!");
	}

	public void GargoyleDeath()
	{
		gargoyleDead = true;
		Debug.Log("Gargoyle died!");
	}

	public void SlimeDeath()
	{
		slimeDead = true;
		Debug.Log("Slime died!");
	}

	public void SpiderDeath()
	{
		spiderDead = true;
		Debug.Log("Spider died!");
	}

	public void PlantMonsterDeath()
	{
		plantMonsterDead = true;
		Debug.Log("Plant monster died!");
	}

	public void DeathKnightDeath()
	{
		deathNightDead = true;
		Debug.Log("Death night died!");
	}

	/* Start() and Update() start here */
	private void Start()
	{
		DontDestroyOnLoad(gameObject);
	}

    void OnLevelWasLoaded() {
        // If NPC level - detect which one, grab health


        // if entrance level, detect portal script
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene.Equals("EntranceScene")){
			// 
            portalRef = FindObjectOfType<PortalReference>();
			// set which portals are active or not 

        }else {
			// in a room with a monster
            GameObject npc = GameObject.FindWithTag("NPC");
			//
            if (npc != null){
                Health npcHealth = npc.GetComponentInChildren<Health>();
                if(npcHealth != null){
					// subscribe to killed event
                    npcHealth.killedEvent.AddListener(NPCKilled);
                }else{
                    Debug.LogWarning("Couldn't find Health");
                }
            }else{
                    Debug.LogWarning("Couldn't find NPC");
            }
        }
    }

    private void NPCKilled(){
		Debug.Log(currentScene + " boss killed" );

        if (currentScene.Equals("Scene1-Skull")) {
            SkullDeath();
        } else if (currentScene.Equals("Scene2-Cat")) {
            CatDeath();
        } else if (currentScene.Equals("Scene3-Gargoyle")) {
            GargoyleDeath();
        } else if (currentScene.Equals("Scene4-Shlime")) {
            SlimeDeath();
        } else if (currentScene.Equals("Scene5-Spider")) {
            SpiderDeath();
        } else if (currentScene.Equals("Scene6-PlantMonster")) {
            PlantMonsterDeath();
        } else if (currentScene.Equals("Scene7-DeathKnight Boss")) {
            DeathKnightDeath();
        } else {
            Debug.LogWarning("Scene not found!");
        }
    }

}
