using Hoguma.Util;
using Colorify;

namespace Hoguma
{
  class Program
  {
    static void Main(string[] args)
    {
      for (int i = 0; i < 5; i++)
        ConsoleUtil.WriteColor("Hello World!");
      ConsoleUtil.Clear();
      // Fixing Colorify bug (console theme not applied)

      ConsoleUtil.WriteColor("\nWelcome To Pumpkin Potato\n", Colors.txtDefault);
      ConsoleUtil.Pause();
      var players = PlayerManager.LoadPlayerData();
      players.Add("새로 만들기");
      players.Add("종료하기");
      ConsoleUtil.Ask(players);
    }
  }
}
