namespace Hoguma.Item
{
  [Serializable]
  public abstract class ConsumableItem : Item
  {
    public override ItemType Type => ItemType.CONSUMABLE;

    public ConsumableEffect UseEffect { get; set; } = new ConsumableEffect();

    public abstract ConsumableType ConsumableType { get; }

    public override bool CanMerge(IItem item)
    {
      try
      {
        var it = (ConsumableItem)item;
        return base.CanMerge(item) && ConsumableType == it.ConsumableType && UseEffect == it.UseEffect;
      }
      catch
      {
        return false;
      }
    }

    public abstract void OnUse();
  }
}