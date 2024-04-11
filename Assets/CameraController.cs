using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraController : MonoBehaviour
{
  public float smoothSpeed = 0.125f;
  public Vector2 offset;
  private Camera cam;
  public Transform[] players;
  public Vector2 zoomBounds;
  public PlayableDirector mainMusic;

  // Start is called before the first frame update
  void Start()
  {
    cam = GetComponent<Camera>();
    mainMusic.Play();
  }

  // Update is called once per frame
  void Update()
  {
    Vector2 middle = Vector2.zero;
    float distance = 0;
    if (players.Length == 0)
    {
      return;
    }
    foreach (Transform player in players)
    {
      middle += (Vector2)player.position;
      for (int i = 0; i < players.Length; i++)
      {
        if (players[i] == player)
          continue;
        distance = Mathf.Max(distance, Vector2.Distance(player.position, players[i].position));
      }
    }
    middle /= players.Length;
    cam.orthographicSize = Mathf.Clamp(distance, zoomBounds.x, zoomBounds.y);
    Vector2 desiredPosition = middle + offset;
    Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
  }
}
