using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
  [SerializeField] GameObject pauseMenu;
  bool paused = false;

  void Start()
  {
    if (!pauseMenu)
    {
      Debug.LogError("Pause Menu was not assigned in PauseMenuManager");
    }

    GameStateManager.OnTogglePause += TogglePauseMenu;
  }

  void TogglePauseMenu()
  {
    paused = !paused;
    pauseMenu.SetActive(paused);
  }

  public void HidePauseMenu()
  {
    paused = false;
    pauseMenu.SetActive(false);
  }
}
