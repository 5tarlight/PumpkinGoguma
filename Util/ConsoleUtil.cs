using Colorify;
using Colorify.UI;
using System;

namespace Hoguma.Util
{
  class ConsoleUtil
  {
    private static Format _colorify = new Format(Theme.Dark);

    public static void WriteLine(string message)
    {
      Console.WriteLine(message);
    }

    public static void Write(string message)
    {
      Console.Write(message);
    }

    public static void WriteColor(string message, string color = Colors.txtDefault)
    {
      _colorify.Write(message, color);
    }
  }
}
