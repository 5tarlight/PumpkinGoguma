namespace Hoguma.Item
{
  public class TestItemE : EquipmentItem
  {
    public override string Name => "Test ItemE";

    public override string Description => "테스트용으로 만들어진 아이템이다!";

    public override EquipmentType EquipmentType => EquipmentType.CHESTPLATE;
  }
}