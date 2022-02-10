using Hoguma.Item;

namespace Hoguma.Inventory
{
  [Serializable]
  public class InventoryItem
  {
    public List<IItem> Items { get; set; }

    public ItemType Type { get; }

    public InventoryItem(ItemType type)
    {
      Items = new List<IItem>();
      Type = type;
    }
  }
}