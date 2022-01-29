using UnityEngine;

public class MovingPlatform : Platform
{

    public bool isMoving = true;
    public float maxDisplacementX = 3.0f;
    public float loopTime = 6.0f;


    [SerializeField] private float currentLoopTime = 0.0f;
    [SerializeField] private Vector3 leftMost;
    [SerializeField] private Vector3 rightMost;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = this.GetComponent<Transform>().position;
        leftMost = currentPosition - new Vector3(maxDisplacementX, 0, 0);
        rightMost = currentPosition + new Vector3(maxDisplacementX, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;

        if (isMoving) { MovementLoop(dt); }
    }

    void MovementLoop(float dt)
    {
        float halfLoopTime = loopTime/2.0f;
        currentLoopTime = (currentLoopTime + dt) % loopTime;
        this.GetComponent<Transform>().position = Vector3.Lerp(leftMost, rightMost, Mathf.Abs(currentLoopTime - halfLoopTime) / halfLoopTime);
    }

}
