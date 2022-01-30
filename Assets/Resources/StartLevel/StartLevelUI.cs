using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;


public class StartLevelUI : MonoBehaviour
{
  UIDocument document;
  VisualElement root;
  [SerializeField] StyleSheet styles;
  [SerializeField] List<TextElement> textElements;

  Box scrollInBox;
  int boxWidth = 0;
  int maxBoxWidth = 650;
  int startTop = 175;
  int endTop = 0;
  int currentTop = 175;
  int currentLeft = 0;
  int minLeft = -650;

  void OnEnable()
  {
    document = GetComponent<UIDocument>();
    root = document.rootVisualElement;

    if (styles)
    {
      root.styleSheets.Add(styles);
    }
  }

  void Start()
  {
    scrollInBox = root.Query<Box>(name: "scroll-container");
    scrollInBox.style.width = 0;
    textElements = root.Query<TextElement>().ToList();
    textElements.ForEach(t =>
    {
      t.style.top = startTop;
    });

    StartCoroutine("ScrollIn");
  }

  IEnumerator ScrollIn()
  {
    yield return new WaitForSeconds(0.5f);
    bool done = false;
    while (!done)
    {
      yield return new WaitForSeconds(0.016f);
      scrollInBox.style.width = (boxWidth += 15);
      if (boxWidth >= maxBoxWidth)
      {
        done = true;
      }
    }
    scrollInBox.style.paddingLeft = 8;
    scrollInBox.style.paddingRight = 8;
    scrollInBox.style.paddingTop = 8;
    scrollInBox.style.paddingBottom = 8;
    yield return new WaitForSeconds(0.5f);
    done = false;
    while (!done)
    {
      yield return new WaitForSeconds(0.016f);
      textElements[0].style.top = (currentTop -= 5);
      done = currentTop <= endTop;
    }
    currentTop = 175;
    yield return new WaitForSeconds(0.5f);
    done = false;
    while (!done)
    {
      yield return new WaitForSeconds(0.016f);
      textElements[1].style.top = (currentTop -= 5);
      done = currentTop <= endTop;
    }
    yield return new WaitForSeconds(4f);
    done = false;
    while (!done)
    {
      scrollInBox.style.left = (currentLeft -= 15);
      done = currentLeft <= minLeft;
      yield return new WaitForSeconds(0.016f);
    }
  }

  public void ResetScroll()
  {
    boxWidth = 0;
    scrollInBox.style.width = boxWidth;
    currentLeft = 0;
  }
}
