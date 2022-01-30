using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningBarrierController : Barrier
{
  void OnTriggerEnter2D(Collider2D other)
  {
    if ("Player".Equals(other.tag))
    {
      GameStateManager.InvokeOnWarningBarrierEnter(CharacterTypeHelper.GetTypeFromName(other.name));
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if ("Player".Equals(other.tag))
    {
      GameStateManager.InvokeOnWarningBarrierExit(CharacterTypeHelper.GetTypeFromName(other.name));
    }
  }
}
