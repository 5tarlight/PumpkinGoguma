namespace Hoguma.Entity.Champion
{
  public interface IChampion
  {
    public abstract string Name { get; }
    public abstract string Nickname { get; set; }
    public abstract double Exp { get; set; }
    public abstract double Level { get; }
    public abstract double BaseAd { get; }
    public abstract double GrowthAd { get; }
    public abstract double Ad { get; }
    public abstract double BaseAp { get; }
    public abstract double GrowthAp { get; }
    public abstract double Ap { get; }

    public abstract void ExpUp(double exp);
  }
}
