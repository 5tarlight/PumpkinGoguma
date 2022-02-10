using Hoguma.Util;
using Hoguma.Inventory;

namespace Hoguma.Entity.Champion
{
  [Serializable]
  public abstract class BaseChampion : IChampion
  {
    public abstract string Name { get; }
    public abstract string Description { get; }
    public string Nickname { get; set; }
    public double Exp { get; set; }
    public double Level
    {
      get
      {
        return Math.Floor(Math.Sqrt(Exp / 100)) + 1;
      }
    }
    public abstract double BaseAd { get; }
    public abstract double GrowthAd { get; }
    public double Ad
    {
      get
      {
        return BaseAd + (GrowthAd * Level);
      }
    }
    public abstract double BaseAp { get; }
    public abstract double GrowthAp { get; }
    public double Ap
    {
      get
      {
        return BaseAp + (GrowthAp * Level);
      }
    }
    public double MaxHp
    {
      get
      {
        return BaseHp + (GrowthHp * Level);
      }
    }
    public double Hp { get; set; }
    public abstract double GrowthHp { get; }
    public abstract double BaseHp { get; }
    public double MaxMp
    {
      get
      {
        return BaseMp + (GrowthMp * Level);

      }
    }
    public double Mp { get; set; }
    public abstract double GrowthMp { get; }
    public abstract double BaseMp { get; }

    public Inventory.Inventory Inventory { get; set; }

    public BaseChampion(string nickname) : base()
    {
      Nickname = nickname;
      Inventory = new Inventory.Inventory();
    }

    public void ExpUp(double exp)
    {
      Exp += exp;
      ConsoleUtil.WriteColor($"{Nickname}의 경험치가 {exp}만큼 올라갔습니다.\n");
    }
  }
}
