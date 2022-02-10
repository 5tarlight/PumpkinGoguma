namespace Hoguma.Item
{
  [Serializable]
  public class EquipmentAbility
  {
    public double IncreaseAd { get; } = 0;

    public double IncreaseAp { get; } = 0;

    public double IncreaseMaxHp { get; } = 0;

    public double IncreaseHp { get; } = 0;

    public double IncreaseMaxMp { get; } = 0;

    public double IncreaseMp { get; } = 0;

    public override bool Equals(object? obj)
    {
      return obj is EquipmentAbility ability &&
             IncreaseAd == ability.IncreaseAd &&
             IncreaseAp == ability.IncreaseAp &&
             IncreaseMaxHp == ability.IncreaseMaxHp &&
             IncreaseHp == ability.IncreaseHp &&
             IncreaseMaxMp == ability.IncreaseMaxMp &&
             IncreaseMp == ability.IncreaseMp;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(IncreaseAd, IncreaseAp, IncreaseMaxHp, IncreaseHp, IncreaseMaxMp, IncreaseMp);
    }
  }
}