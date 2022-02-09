namespace Hoguma.Item
{
  [Serializable]
  public abstract class OtherItem : Item
  {
    public override ItemType Type => ItemType.OTHER;
  }
}