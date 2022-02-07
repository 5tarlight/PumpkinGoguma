using PumpkinGoguma.Item;

namespace PumpkinGoguma.Inventory
{
  public struct SelectedItem
  {
    public ItemType Type { get; set; }
    public int Index { get; set; }

    public SelectedItem(ItemType type, int index)
    {
      Type = type;
      Index = index;
    }
  }
}