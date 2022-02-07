namespace PumpkinGoguma.Item
{
  [Serializable]
  public abstract class Item : IItem
  {
    public abstract string Name { get; }

    public abstract string Description { get; }

    public int Count { get; set; } = 1;

    public abstract ItemType Type { get; }

    public virtual ItemId Id => ItemId.NONE;

  }
}