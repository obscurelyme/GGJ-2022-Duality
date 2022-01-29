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
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      TogglePauseMenu();
    }
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
