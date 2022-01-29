using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{

  public delegate void DeathAction();
  public static event DeathAction OnDeath;

  public delegate void WinAction();
  public static event WinAction OnWin;

  public delegate void PauseAction();
  public static event PauseAction OnTogglePause;

  void Start()
  {
    GameStateManager.OnTogglePause += StopTime;
  }

  void Update()
  {
    //Demo Code
    // if (Input.GetKeyDown(KeyCode.F))
    // {
    //   OnDeath();
    // }
    // if (Input.GetKeyDown(KeyCode.W))
    // {
    //   OnWin();
    // }
    // if (Input.GetKeyDown(KeyCode.P))
    // {
    //   OnTogglePause();
    // }
  }

  void StopTime()
  {
    Time.timeScale = Time.timeScale == 0 ? 1 : 0;
  }

}
