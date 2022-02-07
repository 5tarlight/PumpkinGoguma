namespace Hoguma.Item
{
  [Serializable]
  public abstract class EquipmentItem : Item
  {
    public override ItemType Type => ItemType.EQUIPMENT;

    public abstract EquipmentAbility Ability { get; set; }
  }
}