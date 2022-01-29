using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField]
    internal Vector3 currentPosition;
    void Start()
    {
        currentPosition = this.GetComponent<Transform>().position;
    }
}
