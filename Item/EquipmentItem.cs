namespace PumpkinGoguma.Item
{
  public abstract class EquipmentItem : IItem
  {
    public abstract string Name { get; }

    public abstract string Description { get; }

    public virtual ItemId Id => ItemId.NONE;

    public ItemType Type => ItemType.EQUIPMENT;

    public abstract EquipmentAbility Ability { get; set; }
  }
}