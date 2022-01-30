using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
  UIDocument document;
  VisualElement root;
  [SerializeField] StyleSheet styles;
  [SerializeField] string playSceneName = "MainPlayScene";

  Button playButton;
  [SerializeField] AudioSource clickSource;
  [SerializeField] AudioSource hoverSource;
  void Awake()
  {
    document = GetComponent<UIDocument>();
    root = document.rootVisualElement;
    playButton = root.Query<Button>(name: "button-play");
  }

  void OnEnable()
  {
    if (styles)
    {
      root.styleSheets.Add(styles);
    }

    playButton.RegisterCallback<ClickEvent>(HandlePlayButtonClick);
    playButton.RegisterCallback<MouseEnterEvent>(HandlePlayButtonHover);
  }

  void OnDisable()
  {
    playButton.UnregisterCallback<ClickEvent>(HandlePlayButtonClick);
    playButton.UnregisterCallback<MouseEnterEvent>(HandlePlayButtonHover);
  }

  void HandlePlayButtonClick(ClickEvent evt)
  {
    if (playSceneName != "")
    {
      SceneManager.LoadScene(playSceneName);
      clickSource.Play();
    }
  }

  void HandlePlayButtonHover(MouseEnterEvent evt)
  {
    hoverSource.Play();
  }
}
