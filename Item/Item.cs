namespace PumpkinGoguma.Item
{
  public abstract class Item : IItem
  {
    public abstract string Name { get; }

    public abstract string Description { get; }

    public abstract ItemType Type { get; }

    public virtual ItemId Id => ItemId.NONE;

  }
}