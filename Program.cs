using Hoguma.Util;
using Colorify;

namespace Hoguma
{
  class Program
  {
    static void Main(string[] args)
    {
      AppDomain.CurrentDomain.ProcessExit += OnProcessEnd;

      for (int i = 0; i < 5; i++)
        ConsoleUtil.WriteColor("Hello World!");
      ConsoleUtil.Clear();
      // Fixing Colorify bug (console theme not applied)

      var players = PlayerManager.LoadPlayerList();

      while (true)
      {
        var hasPlayerData = players.Count > 0;
        var options = new List<string>() { "새로 만들기" };
        if (hasPlayerData) options.Add("이어 하기");
        options.Add("종료 하기");

        var action = ConsoleUtil.Ask("\nWelcome To Pumpkin Potato\n", options);

        if (action.Index == 0)
        {
          // Create new champion
          if (PlayerManager.CreatePlayer())
            Hoguma.Game.Main.ShowMenu();
        }
        else if (action.Index == 1 && hasPlayerData)
        {
          // Load player data
          var loadPlayer = ConsoleUtil.Ask("\n이어 할 챔피언을 선택하세요.\n", players, true);
          if (loadPlayer.IsCancel) continue;
          PlayerManager.LoadPlayerData(players[loadPlayer.Index]);

          Hoguma.Game.Main.ShowMenu();
        }
        else if (action.Index == 2 || (action.Index == 1 && !hasPlayerData))
        {
          // Exit.
          Environment.Exit(0);
        }
      }
    }

    static void OnProcessEnd(object? sender, EventArgs e)
    {
      ConsoleUtil.Clear();
      ConsoleUtil.WriteColor("저장하는 중...");
      // Save everything
    }
  }
}
