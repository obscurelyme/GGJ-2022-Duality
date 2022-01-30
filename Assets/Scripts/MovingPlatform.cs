using UnityEngine;

public class MovingPlatform : Platform
{

  [SerializeField] bool isMirror = false;
  public bool isMoving = true;
  public float maxDisplacementX = 3.0f;
  public float loopTime = 6.0f;


  [SerializeField] private float currentLoopTime = 0.0f;
  [SerializeField] [Range(0.0f, 1.0f)] private float offsetLoopRatio = 0.0f;

  public Transform Platform;
  public Transform leftMost;
  public Transform rightMost;

  private void Start()
  {
    if (isMirror)
    {
      Vector3 temp = rightMost.position;
      rightMost.position = leftMost.position;
      leftMost.position = temp;
    }
    currentLoopTime = offsetLoopRatio * loopTime;
  }
  // Update is called once per frame
  void Update()
  {
    float dt = Time.deltaTime;

    if (isMoving) { MovementLoop(dt); }

  }

  void MovementLoop(float dt)
  {
    float halfLoopTime = loopTime / 2.0f;
    currentLoopTime = (currentLoopTime + dt) % loopTime;
    Platform.position = Vector3.Lerp(leftMost.position, rightMost.position, Mathf.Abs(currentLoopTime - halfLoopTime) / halfLoopTime);
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    if ("Player".Equals(collision.gameObject.tag))
    {
      collision.collider.transform.SetParent(Platform);
    }
  }

  void OnCollisionExit2D(Collision2D collision)
  {
    if ("Player".Equals(collision.gameObject.tag))
    {
      collision.collider.transform.SetParent(null);
    }
  }
}
