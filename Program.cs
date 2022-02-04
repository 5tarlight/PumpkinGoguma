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
      ConsoleUtil.Ask(new List<string>() { "Start Game", "Exit" });
    }
  }
}
