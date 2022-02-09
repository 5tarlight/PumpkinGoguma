namespace Hoguma.Item
{
  [Serializable]
  public abstract class ConsumableItem : Item
  {
    public override ItemType Type => ItemType.CONSUMABLE;

    public abstract ConsumableEffect UseEffect { get; set; }

  }
}