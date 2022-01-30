using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

public class WinPanelUI : MonoBehaviour
{
  UIDocument document;
  VisualElement root;
  [SerializeField] StyleSheet styles;

  Box banner;
  List<TextElement> text;

  [SerializeField] int maxHeight = 75;
  int currentHeight = 0;
  [SerializeField] bool isTextHiding = true;
  [SerializeField] GameStateManager manager;

  void OnEnable()
  {
    GameStateManager.OnWin += HandleWinEvent;
    document = GetComponent<UIDocument>();
    root = document.rootVisualElement;
    if (styles)
    {
      root.styleSheets.Add(styles);
    }

    banner = root.Query<Box>(name: "scrolling-banner");
    text = banner.Query<TextElement>().ToList();
    banner.style.height = currentHeight;
    banner.style.paddingBottom = 0;
    banner.style.paddingTop = 0;
    banner.style.paddingLeft = 0;
    banner.style.paddingRight = 0;
  }

  void OnDisable()
  {
    GameStateManager.OnWin -= HandleWinEvent;
  }

  void HandleWinEvent()
  {
    StartCoroutine("PopIntoView");
  }

  IEnumerator PopIntoView()
  {
    root.AddToClassList("overlay");
    bool done = false;
    while (!done)
    {
      if (currentHeight >= 50 && isTextHiding)
      {
        ShowText();
        ShowPadding();
      }
      currentHeight += 10;
      banner.style.height = currentHeight;
      done = currentHeight >= maxHeight;
      yield return new WaitForSeconds(0.016f);
    }
  }

  void ShowText()
  {
    text.ForEach(t =>
    {
      t.RemoveFromClassList("text__hidden");
    });
    isTextHiding = false;
  }

  void ShowPadding()
  {
    banner.style.paddingBottom = 8;
    banner.style.paddingTop = 8;
    banner.style.paddingLeft = 8;
    banner.style.paddingRight = 8;
  }
}
