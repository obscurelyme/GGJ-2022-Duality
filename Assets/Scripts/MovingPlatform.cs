using UnityEngine;

public class MovingPlatform : Platform
{

    public bool isMoving = true;
    public float maxDisplacementX = 3.0f;
    public float loopTime = 6.0f;


    [SerializeField] private float currentLoopTime = 0.0f;
    public Transform Platform;
    public Transform leftMost;
    public Transform rightMost;

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

}
