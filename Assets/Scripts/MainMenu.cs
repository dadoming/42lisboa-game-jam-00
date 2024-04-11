using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class MainMenu : MonoBehaviour
{
    public PlayableDirector playableDirector = null;

	public void Start() {
		if (playableDirector != null)
			playableDirector.Play();
	}
	public void PlayGame()
	{
		if (playableDirector != null)
			playableDirector.Stop();
		 // in build_settings, the first scene is at index 0 -> MainMenu and it plays the next one
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame()
	{
		if (playableDirector != null)
			playableDirector.Stop();
		Debug.Log("QUIT!");
		Application.Quit();
	}
}
