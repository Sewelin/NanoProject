using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Vibration : MonoBehaviour
{
  private const float Duration = 0.2f;
  private const float LowFrequency = 0.1f;
  private const float HighFrequency = 0.7f;

  public void Begin(AbstractController controller)
  {
    var devices = controller.GetComponent<PlayerInput>().devices;
    var gamepad = GetGamepadFromDevices(devices);
    if (gamepad == null) return;
    
    gamepad.SetMotorSpeeds(LowFrequency,HighFrequency);
    StartCoroutine(Stop(gamepad));
  }

  private IEnumerator Stop(Gamepad gamepad)
  {
    yield return new WaitForSeconds(Duration);
    gamepad.SetMotorSpeeds(0,0);
  }

  private static Gamepad GetGamepadFromDevices(ReadOnlyArray<InputDevice> inputDevice)
  {
    foreach (var device in inputDevice)
    {
      if (device is Gamepad gamepad)
        return gamepad;
    }
    return null;
  }
}