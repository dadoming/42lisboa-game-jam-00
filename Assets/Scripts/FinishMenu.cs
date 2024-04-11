using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
  public CanvasFinish canvas;

  void Start()
  {
  }

  public void RestartGame()
  {
    if (canvas.isPaused)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      Time.timeScale = 1f;
      canvas.isPaused = false;
    }
  }

  // Update is called once per frame
  void Update()
  {

  }



  public void QuitGame()
  {
    if (canvas.isPaused)
      Application.Quit();
  }
}
