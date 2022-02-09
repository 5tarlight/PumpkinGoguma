using Hoguma.Item;

namespace Hoguma.Inventory
{
  [Serializable]
  public class InventoryItem
  {
    private List<IItem> items;
    public List<IItem> Items
    {
      get => items.OrderBy(x => x.Name).ToList();
      set => items = value;
    }

    public ItemType Type { get; }

    public InventoryItem(ItemType type)
    {
      items = new List<IItem>();
      Type = type;
    }
  }
}