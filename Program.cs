using Hoguma.Util;
using Colorify;

namespace Hoguma
{
  class Program
  {
    static void Main(string[] args)
    {
      ConsoleUtil.WriteColor("\nWelcome To Pumpkin Potato\n", Colors.txtDefault);
      ConsoleUtil.Pause();
      ConsoleUtil.Ask(new List<string>() { "Start Game", "Exit" });
    }
  }
}
