using Hoguma.Item;

namespace Hoguma.Inventory
{
  public class EquipmentInv
  {
    public List<EquipmentInvItem> Items { get; set; }

    public EquipmentInv()
    {
      Items = new List<EquipmentInvItem>();
      var typeCount = Enum.GetValues(typeof(EquipmentType)).Length;

      for (var i = 0; i < typeCount; i++)
      {
        Items.Add(new EquipmentInvItem((EquipmentType)i));
      }
    }

    private EquipmentInvItem GetInvItem(EquipmentType equipmentType) => Items.Single(x => x.Type == equipmentType);

    public EquipmentItem? GetItem(EquipmentType equipmentType)
    {
      return GetInvItem(equipmentType).Item;
    }

    public void Change(EquipmentItem afterItem, out EquipmentItem? beforeItem)
    {
      var inv = Items[Items.IndexOf(GetInvItem(afterItem.EquipmentType))];
      beforeItem = inv.Item;
      inv.Item = afterItem;
    }

    public void Remove(EquipmentType equipmentType, out EquipmentItem? beforeItem)
    {
      var inv = Items[Items.IndexOf(GetInvItem(equipmentType))];
      beforeItem = inv.Item;
      inv.Item = null;
    }
  }
}