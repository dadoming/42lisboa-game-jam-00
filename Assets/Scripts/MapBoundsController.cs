using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapBoundsController : MonoBehaviour
{
  // private BoxCollider2D boxCollider;
  // Start is called before the first frame update
  // void Start()
  // {
  //   // this.boxCollider = GetComponent<BoxCollider2D>();
  //   // this.boxCollider.size = new Vector2(Screen.width, Screen.height);
  // }
  
  void OnTriggerEnter2D(Collider2D other)
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
