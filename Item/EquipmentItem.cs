namespace Hoguma.Item
{
  [Serializable]
  public abstract class EquipmentItem : Item
  {
    public override ItemType Type => ItemType.EQUIPMENT;

    public EquipmentAbility Ability { get; set; } = new EquipmentAbility();

    public abstract EquipmentType EquipmentType { get; }

    public override bool Equals(object? obj)
    {
      return obj is EquipmentItem ite &&
             base.Equals(obj) &&
             EquipmentType == ite.EquipmentType &&
             Ability.Equals(ite.Ability);
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(base.GetHashCode, EquipmentType, Ability);
    }


    public void OnEquip()
    {
      // to do
    }
  }
}