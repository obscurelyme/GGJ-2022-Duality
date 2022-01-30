public enum CharacterType
{
  Witch,
  Cat,
  Unknown
}

public static class CharacterTypeHelper
{

  public static CharacterType GetTypeFromName(string name)
  {
    switch (name)
    {
      case "Witch":
        return CharacterType.Witch;
      case "Cat":
        return CharacterType.Cat;
      default:
        return CharacterType.Unknown;
    }
  }
}

