using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Audio;
using UnityEngine.Playables;

public class CollectableObject : MonoBehaviour
{
  public bool isRespawnable = false;
  public float respawnTime = 5.0f;
  private bool isRespawning = false;
  private float initialRespawnTime; // Store the initial respawn time
  private SpriteRenderer spriteRenderer;
  private Light2D selfLight;
  public GameObject destroyEffect = null;

  void Start()
  {
    initialRespawnTime = respawnTime; // Store the initial respawn time
    spriteRenderer = GetComponent<SpriteRenderer>();
    selfLight = GetComponent<Light2D>();
  }

  void Update()
  {
    if (isRespawning)
    {
      respawnTime -= Time.deltaTime;
      if (respawnTime <= 0)
      {
        isRespawning = false;
        respawnTime = initialRespawnTime; // Reset respawnTime to initial value
        SwitchRenderingState();
      }
    }
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player") && !isRespawning)
    {
      PlayerLightController player = other.gameObject.GetComponent<PlayerLightController>();
      player.OnBatteryPickup();
      if (isRespawnable)
      {
        SwitchRenderingState();
        isRespawning = true;
      }
      else
      {
        Destroy(gameObject);
        if (destroyEffect != null)
          Instantiate(destroyEffect, transform.position, Quaternion.identity);
      }
    }
  }

  void SwitchRenderingState()
  {
    spriteRenderer.enabled = !spriteRenderer.enabled;
    selfLight.enabled = !selfLight.enabled;
  }

}
