using UnityEngine;

public class MovingPlatform : Platform
{

  public bool isMoving;
  public float maxDisplacementX;

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
