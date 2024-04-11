using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFinish : MonoBehaviour
{
  public FinishMenu finishMenuUI;
  public bool isPaused = false;
  public Camera mainCamera;

  // Start is called before the first frame update
  void Start()
  {
    finishMenuUI.gameObject.SetActive(false);
  }

  // Update is called once per frame
  public void ToggleFinishMenu()
  {
    // Toggle the visibility of the pause menu
    isPaused = !isPaused;

    if (isPaused)
    {
      Debug.Log("Pause Menu Active");
      Time.timeScale = 0f; // Pause the game
      finishMenuUI.gameObject.SetActive(true);
    }
    else
    {
      Debug.Log("Pause Menu Inactive");
      Time.timeScale = 1f; // Resume the game
      finishMenuUI.gameObject.SetActive(false);
    }
  }
}
