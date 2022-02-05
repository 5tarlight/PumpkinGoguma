namespace PumpkinGoguma.Item
{
  public interface IItem
  {
    string Name { get; set; }
    string Explanation { get; set; }
    ItemType Type { get; set; }
    ItemAbility Ability { get; set; }
  }
}