using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
  [SerializeField] private float offsetFromCameraBottom;

  void Update()
  {
    Camera camera = Camera.main;
    float cameraBottom = camera.orthographicSize;

    this.transform.position = new Vector2(camera.transform.position.x, camera.transform.position.y + -offsetFromCameraBottom * cameraBottom);
  }
}
