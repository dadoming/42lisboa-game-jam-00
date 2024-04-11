using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPause : MonoBehaviour
{
	public PauseMenu pauseMenuUI;
	public bool isPaused = false;
	public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
		pauseMenuUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

	public void TogglePauseMenu()
    {
        // Toggle the visibility of the pause menu
        isPaused = !isPaused;

        if (isPaused)
        {
			Debug.Log("Pause Menu Active");
            Time.timeScale = 0f; // Pause the game
			pauseMenuUI.gameObject.SetActive(true);
		}
        else
        {
			Debug.Log("Pause Menu Inactive");
            Time.timeScale = 1f; // Resume the game
			pauseMenuUI.gameObject.SetActive(false);
        }
    }
}
