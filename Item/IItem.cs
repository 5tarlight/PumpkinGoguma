namespace PumpkinGoguma.Item
{
  public interface IItem
  {
    string Name { get; }
    string Description { get; }
    int Count { get; set; }
    ItemId Id { get; }
    ItemType Type { get; }
  }
}