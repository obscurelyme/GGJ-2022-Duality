using UnityEngine;
using UnityEngine.UIElements;

public class TitleUI : MonoBehaviour
{
  UIDocument document;
  VisualElement root;
  [SerializeField] StyleSheet styles;

  void Awake()
  {
    document = GetComponent<UIDocument>();
    root = document.rootVisualElement;
  }

  void OnEnable()
  {
    if (styles)
    {
      root.styleSheets.Add(styles);
    }
  }

  void Start()
  {

  }
}
