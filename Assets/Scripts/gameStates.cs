using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStates : MonoBehaviour
{
	public void changeScene( string sceneName )
	{
		SceneManager.LoadScene( sceneName );
	}

	public void exit()
	{
		Application.Quit();
	}
}
