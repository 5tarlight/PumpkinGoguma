using Hoguma.Item;

namespace Hoguma.Inventory
{
  [Serializable]
  public class EquipmentInvItem
  {
    public EquipmentItem? Item { get; set; } = null;

    public EquipmentType Type { get; }

    public EquipmentInvItem(EquipmentType type)
    {
      Type = type;
    }
  }
}