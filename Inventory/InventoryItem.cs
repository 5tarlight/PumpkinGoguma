using PumpkinGoguma.Item;

namespace PumpkinGoguma.Inventory
{
  public class InventoryItem
  {
    public List<IItem> Items { get; set; } = new List<IItem>();

    public ItemType Type { get; }

    public InventoryItem(ItemType type)
    {
      Type = type;
    }
  }
}