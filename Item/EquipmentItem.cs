namespace Hoguma.Item
{
  [Serializable]
  public abstract class EquipmentItem : Item
  {
    public override ItemType Type => ItemType.EQUIPMENT;

    public EquipmentAbility Ability { get; set; }

    public abstract EquipmentType EquipmentType { get; }
  }
}