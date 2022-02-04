using Hoguma.Util;

namespace Hoguma.Entity.Champion
{
  public class BaseChampion : IChampion
  {
    public string Name { get; }
    public string Nickname { get; set; }
    public double Exp { get; set; }
    public double Level
    {
      get
      {
        return Math.Floor(Math.Sqrt(Exp / 100)) + 1;
      }
    }
    public double BaseAd { get; }
    public double GrowthAd { get; }
    public double Ad
    {
      get
      {
        return BaseAd + (GrowthAd * Level);
      }
    }
    public double BaseAp { get; }
    public double GrowthAp { get; }
    public double Ap
    {
      get
      {
        return BaseAp + (GrowthAp * Level);
      }
    }

    public BaseChampion(string name, string nickname, double ad, double ap)
    {
      Name = name;
      Nickname = nickname;
      Exp = 0;
      BaseAd = ad;
      BaseAp = ap;
    }

    public void ExpUp(double exp)
    {
      Exp += exp;
      ConsoleUtil.WriteColor($"{Nickname}의 경험치가 {exp}만큼 올라갔습니다.\n");
    }
  }
}
