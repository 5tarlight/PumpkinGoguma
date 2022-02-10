namespace Hoguma.Item
{
  [Serializable]
  public abstract class ConsumableItem : Item
  {
    public override ItemType Type => ItemType.CONSUMABLE;

    public ConsumableEffect UseEffect { get; set; } = new ConsumableEffect();

    public abstract ConsumableType ConsumableType { get; }

    public override bool Equals(object? obj)
    {
      return obj is ConsumableItem item &&
             base.Equals(obj) &&
             ConsumableType == item.ConsumableType &&
             UseEffect.Equals(item.UseEffect);
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(base.GetHashCode, UseEffect, ConsumableType);
    }

    public abstract void OnUse();
  }
}