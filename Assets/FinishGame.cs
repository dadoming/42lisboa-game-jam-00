using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
  public CanvasFinish finishMenu;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void OnTriggerEnter2D()
  {
    finishMenu.ToggleFinishMenu();
  }
}
