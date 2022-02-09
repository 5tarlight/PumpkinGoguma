namespace Hoguma.Item
{
  [Serializable]
  public abstract class ConsumableItem : Item
  {
    public override ItemType Type => ItemType.CONSUMABLE;

    public ConsumableEffect UseEffect { get; set; }

  }
}