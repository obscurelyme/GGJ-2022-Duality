using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
  UIDocument document;
  VisualElement root;
  [SerializeField] StyleSheet styles;

  Button resumeButton;
  Button controlsButton;

  [SerializeField] PauseMenuManager pauseMenuManager;

  void OnEnable()
  {
    document = GetComponent<UIDocument>();
    root = document.rootVisualElement;
    resumeButton = root.Query<Button>(name: "button-resume");
    controlsButton = root.Query<Button>(name: "button-controls");

    if (styles)
    {
      root.styleSheets.Add(styles);
    }

    resumeButton.RegisterCallback<ClickEvent>(HandleResumeButtonClick);
  }

  void OnDisable()
  {
    resumeButton.UnregisterCallback<ClickEvent>(HandleResumeButtonClick);
  }

  void HandleResumeButtonClick(ClickEvent evt)
  {
    resumeButton.Blur();
    pauseMenuManager.HidePauseMenu();
  }
}
