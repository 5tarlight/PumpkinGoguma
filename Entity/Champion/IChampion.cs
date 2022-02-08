using PumpkinGoguma.Inventory;

namespace Hoguma.Entity.Champion
{
  public interface IChampion
  {
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract string Nickname { get; set; }
    public abstract double Exp { get; set; }
    public abstract double Level { get; }
    public abstract double MaxHp { get; }
    public abstract double Hp { get; set; }
    public abstract double GrowthHp { get; }
    public abstract double BaseHp { get; }
    public abstract double MaxMp { get; }
    public abstract double Mp { get; set; }
    public abstract double GrowthMp { get; }
    public abstract double BaseMp { get; }
    public abstract double BaseAd { get; }
    public abstract double GrowthAd { get; }
    public abstract double Ad { get; }
    public abstract double BaseAp { get; }
    public abstract double GrowthAp { get; }
    public abstract double Ap { get; }

    public abstract Inventory Inventory { get; }

    public abstract void ExpUp(double exp);
  }
}
