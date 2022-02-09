namespace Hoguma.Item
{
  [Serializable]
  public abstract class EquipmentItem : Item
  {
    public override ItemType Type => ItemType.EQUIPMENT;

    public EquipmentAbility Ability { get; set; } = new EquipmentAbility();

    public abstract EquipmentType EquipmentType { get; }

    public override bool CanMerge(IItem item)
    {
      try
      {
        var it = (EquipmentItem)item;
        return base.CanMerge(item) && EquipmentType == it.EquipmentType && Ability == it.Ability;
      }
      catch
      {
        return false;
      }
    }

    public void OnEquip()
    {
      // to do
    }
  }
}