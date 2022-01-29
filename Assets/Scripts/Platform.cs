using UnityEngine;

public class Platform : MonoBehaviour
{

  internal Vector3 currentPosition;

  // Start is called before the first frame update
  void Start()
  {
    currentPosition = this.GetComponent<Transform>().position;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
