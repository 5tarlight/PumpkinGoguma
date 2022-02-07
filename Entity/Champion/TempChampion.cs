namespace Hoguma.Entity.Champion
{
  [Serializable]
  public sealed class TempChampion : BaseChampion
  {
    public TempChampion(string nickname) : base(nickname)
    { }

    public override string Name => "임시 캐릭터";

    public override string Description => "개발자의 가호가 깃든 캐릭터입니다. 희귀하긴 하죠...";

    public override double BaseAd => 50;

    public override double GrowthAd => 12;

    public override double BaseAp => 5;

    public override double GrowthAp => 4;

    public override double GrowthHp => 120;

    public override double BaseHp => 550;

    public override double GrowthMp => 90;

    public override double BaseMp => 100;

    public override string? ToString()
    {
      return base.ToString();
    }
  }
}
