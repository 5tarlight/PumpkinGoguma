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

      ConsoleUtil.WriteColor("\nWelcome To Pumpkin Potato\n");
      ConsoleUtil.Pause();
      var players = PlayerManager.LoadPlayerList();
      players.Add("새로 만들기");
      players.Add("종료하기");
      while (true)
      {
        var action = ConsoleUtil.Ask("무엇을 하시겠습니까", players);
        PlayerManager.LoadPlayerData(players[action]);
        /*
          @todo Remove this statement
          @body This statement is for testing. Check if player loading is working.
        */
        ConsoleUtil.WriteColor($"Player loaded! {PlayerManager.CurrentChampion.Name} - {PlayerManager.CurrentChampion.Nickname}");

        if (action >= players.Count - 2)
        {
          // Create or Exit
          if (action == players.Count - 2)
          {
            // Create new champion
            PlayerManager.CreatePlayer();
          }
          else
          {
            // Exit
            Environment.Exit(0);
          }
        }
      }
    }

    static void OnProcessEnd(object? sender, EventArgs e)
    {
      ConsoleUtil.WriteColor("저장하는 중...");
      // Save everything
    }
  }
}
