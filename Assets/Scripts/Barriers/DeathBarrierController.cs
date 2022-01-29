using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrierController : Barrier
{

  void OnTriggerEnter2D(Collider2D other)
  {
    if ("Player".Equals(other.tag))
    {
      GameStateManager.InvokeOnDeath();
    }
  }
}
