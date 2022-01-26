using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
	[Header("Inputs")]
	public AudioSource deathSound;
	public GameObject deathUI;
	public float respawnWaitTime;
	public string sceneToLoad;

	private bool respawnTimer = false;

    public void Start()
    {
		PlayerController pc = FindObjectOfType<PlayerController>();
		Health playerHealth = pc.GetComponent<Health>();
		playerHealth.killedEvent.AddListener(OnDeath);
    }

    public void OnDeath()
	{
		Debug.Log("Player Died");
		if (deathSound != null)
			deathSound.Play();
		else
			Debug.Log("Death Sound missing on DeathScript");

		if( deathUI != null)
			deathUI.SetActive(true);
		else
			Debug.Log("Death Sound missing on DeathScript");

		respawnTimer = true;
	}

	private void Update()
	{
		if (respawnTimer)
		{
			respawnWaitTime -= Time.deltaTime;
		}

		if(respawnWaitTime <= 0)
		{
			SceneManager.LoadScene(sceneToLoad);
		}
	}
}
