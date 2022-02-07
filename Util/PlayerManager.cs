using Hoguma.Entity.Champion;

namespace Hoguma.Util
{
  public class PlayerManager
  {
    private static string Sep = Path.DirectorySeparatorChar.ToString();
    private static string PlayerDataPath = $"{Directory.GetCurrentDirectory()}{Sep}PlayerData";
    private static string Suffix = ".pdata";
    private static List<string> champions = new List<string>() {
      "임시 캐릭터"
    };

    public static BaseChampion CurrentChampion { get; set; }

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

    private static bool IsNameValid(string? s)
    {
      if (s == null || s.Length > 20)
        return false;

      var invalid = false;
      foreach (var c in Path.GetInvalidFileNameChars())
      {
        if (s.Contains(c))
        {
          invalid = true;
          break;
        }
      }
      return !invalid;
    }

    public static void CreatePlayer()
    {
      CheckDirectory();
      var res = ConsoleUtil.Ask("캐릭터를 선택하세요", champions, true);
      var champ = res.Index;
      if (res.IsCancel)
        return;
      var nickname = ConsoleUtil.ReadLine("닉네임 : ", IsNameValid);

      BaseChampion champion;

      switch (champ)
      {
        case 0:
          champion = new TempChampion(nickname);
          break;
        default:
          champion = new TempChampion(nickname); // This is not intended working
          break;
      }
    }

    public static bool SavePlayerData(BaseChampion champion)
    {
      return true;
    }
  }
}
