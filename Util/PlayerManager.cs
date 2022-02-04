using Hoguma.Entity.Champion;

namespace Hoguma.Util
{
  public class PlayerManager
  {
    private static string Sep = Path.DirectorySeparatorChar.ToString();
    private static string PlayerDataPath = $"{Directory.GetCurrentDirectory()}{Sep}PlayerData";
    private static string Suffix = ".pdata";

    private static void CheckDirectory()
    {
      if (!Directory.Exists(PlayerDataPath))
        Directory.CreateDirectory(PlayerDataPath);
    }

    public static List<string> LoadPlayerList()
    {
      CheckDirectory();
      return Directory.GetFiles(PlayerDataPath).ToList().FindAll(x => x.EndsWith(Suffix));
    }
  }
}
