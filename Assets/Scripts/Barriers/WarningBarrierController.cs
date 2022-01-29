using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningBarrierController : Barrier
{
  void OnTriggerStay2D(Collider2D other)
  {
    if ("Player".Equals(other.tag))
    {
      GameStateManager.InvokeOnWarningBarrierStay(other);
    }
  }
}
