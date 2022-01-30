using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{

  private Dictionary<CharacterType, bool> charactersInCollider;

  void Start()
  {
    charactersInCollider = new Dictionary<CharacterType, bool>{
      {CharacterType.Cat, false},
      {CharacterType.Witch, false}
    };
  }

  private void CheckForWin()
  {
    if (charactersInCollider[CharacterType.Cat] && charactersInCollider[CharacterType.Witch])
    {
      GameStateManager.InvokeOnWin();
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if ("Player".Equals(other.tag))
    {
      charactersInCollider[CharacterTypeHelper.GetTypeFromName(other.name)] = true;
    }

    CheckForWin();
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if ("Player".Equals(other.tag))
    {
      charactersInCollider[CharacterTypeHelper.GetTypeFromName(other.name)] = false;
      Debug.Log(charactersInCollider);
    }
  }
}
