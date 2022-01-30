using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

public static class WarningNotification
{
  public static readonly string WitchInDanger = "Witch is in danger of being left behind!";
  public static readonly string CatInDanger = "Cat is in danger of being left behind!";
  public static readonly string WitchSaved = "Witch is safe for now.";
  public static readonly string CatSaved = "Cat is safe for now.";
}

public class WarningNotificationsUI : MonoBehaviour
{
  UIDocument document;
  VisualElement root;
  [SerializeField] StyleSheet styles;
  VisualElement area;
  Box banner;
  List<TextElement> text;
  [SerializeField] int maxHeight = 125;
  int currentHeight = 0;
  [SerializeField] bool isTextHiding = true;
  bool isShowingNotification = false;
  [SerializeField] GameStateManager manager;

  void OnEnable()
  {
    GameStateManager.OnWarningBarrierEnter += HandleWarning;
    GameStateManager.OnWarningBarrierExit += HandleWarningStop;
    document = GetComponent<UIDocument>();
    root = document.rootVisualElement;
    if (styles)
    {
      root.styleSheets.Add(styles);
    }

    area = root.Query<VisualElement>(name: "notification-area");
    banner = root.Query<Box>(name: "notification-banner");
    text = banner.Query<TextElement>().ToList();

    HideNotification();
  }

  void OnDisable()
  {
    GameStateManager.OnWarningBarrierEnter -= HandleWarning;
    GameStateManager.OnWarningBarrierExit -= HandleWarningStop;
  }

  void HandleWarning(CharacterType character)
  {
    if (!isShowingNotification)
    {
      if (character == CharacterType.Witch)
      {
        DisplayLeft();
        StartCoroutine("ShowWarningNotification");
        return;
      }
      if (character == CharacterType.Cat)
      {
        DisplayRight();
        StartCoroutine("ShowWarningNotification");
        return;
      }
    }
  }

  void HandleWarningStop(CharacterType character)
  {
    if (character == CharacterType.Witch)
    {
      return;
    }
    if (character == CharacterType.Cat)
    {
      return;
    }
  }

  IEnumerator ShowWarningNotification()
  {
    isShowingNotification = true;
    bool done = false;
    while (!done)
    {
      if (currentHeight >= 75 && isTextHiding)
      {
        ShowText();
        ShowPadding();
      }
      currentHeight += 20;
      banner.style.height = currentHeight;
      done = currentHeight >= maxHeight;
      yield return new WaitForSeconds(0.016f);
    }
    yield return new WaitForSeconds(2.0f);
    HideNotification();
    isShowingNotification = false;
  }

  void HideNotification()
  {
    currentHeight = 0;
    banner.style.height = currentHeight;
    banner.style.paddingBottom = 0;
    banner.style.paddingTop = 0;
    banner.style.paddingLeft = 0;
    banner.style.paddingRight = 0;
    HideText();
  }

  void DisplayLeft()
  {
    area.RemoveFromClassList("right-side");
    area.AddToClassList("left-side");
  }

  void DisplayRight()
  {
    area.RemoveFromClassList("left-side");
    area.AddToClassList("right-side");
  }

  void ShowText()
  {
    text.ForEach(t =>
    {
      t.RemoveFromClassList("text__hidden");
    });
    isTextHiding = false;
  }

  void HideText()
  {
    text.ForEach(t =>
    {
      t.AddToClassList("text__hidden");
    });
    isTextHiding = true;
  }

  void ShowPadding()
  {
    banner.style.paddingBottom = 8;
    banner.style.paddingTop = 8;
    banner.style.paddingLeft = 8;
    banner.style.paddingRight = 8;
  }
}
