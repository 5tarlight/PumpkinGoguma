namespace PumpkinGoguma.Item
{
  public interface IItem
  {
    string Name { get; }
    string Description { get; }
    ItemId Id { get; }
    ItemType Type { get; }
  }
}