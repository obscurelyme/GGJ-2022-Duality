using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameStateManager : MonoBehaviour
{

  public delegate void WarningAreaEnterAction(CharacterType character);
  public static event WarningAreaEnterAction OnWarningBarrierEnter;
  public static void InvokeOnWarningBarrierEnter(CharacterType character)
  {
    OnWarningBarrierEnter(character);
  }

  public delegate void WarningAreaExitAction(CharacterType character);
  public static event WarningAreaExitAction OnWarningBarrierExit;
  public static void InvokeOnWarningBarrierExit(CharacterType character)
  {
    OnWarningBarrierExit(character);
  }

  public delegate void DeathAction();
  public static event DeathAction OnDeath;
  public static void InvokeOnDeath()
  {
    OnDeath();
  }

  public delegate void WinAction();
  public static event WinAction OnWin;
  public static void InvokeOnWin()
  {
    OnWin();
  }

  public delegate void PauseAction();
  public static event PauseAction OnTogglePause;
  public static void InvokeOnTogglePause()
  {
    OnTogglePause();
  }

  void Start()
  {
    GameStateManager.OnTogglePause += StopTime;
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      OnTogglePause();
    }
  }

  void StopTime()
  {
    Time.timeScale = Time.timeScale == 0 ? 1 : 0;
  }

}
