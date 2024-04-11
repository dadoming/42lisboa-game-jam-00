using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLightController : MonoBehaviour
{
  private bool _lightisOn = false;
  private bool _lightCooldown = false;
  private int targetLightRadius = 1;
  private Light2D selfLight;
  private PlayerKeybindsController binds;
  public int batteries = 0;
  // Start is called before the first frame update
  void Start()
  {
    selfLight = GetComponent<PlayerRigController>().selfLight;
    binds = GetComponent<PlayerKeybindsController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (batteries > 0 && !_lightisOn && !_lightCooldown && Input.GetKeyDown(binds.interact))
      StartCoroutine(TurnLightOn());
    selfLight.shapeLightFalloffSize = Mathf.Lerp(selfLight.shapeLightFalloffSize, targetLightRadius * .18f, Time.deltaTime);
  }
  public IEnumerator TurnLightOn()
  {
    if (_lightisOn || _lightCooldown) yield break;
    _lightisOn = true;
    targetLightRadius = 3 * batteries;
    yield return new WaitForSeconds(2.0f * batteries);
    targetLightRadius = 1;
    _lightisOn = false;
    _lightCooldown = true;
    yield return new WaitForSeconds(5.0f / batteries);
    _lightCooldown = false;
  }
  public void OnBatteryPickup()
  {
    batteries++;
  }
}
