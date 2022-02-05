using Colorify;
using Colorify.UI;
using System;
using System.Collections.Generic;

namespace Hoguma.Util
{
  class AskResponse
  {
    public AskResponse(int index, bool isCancel)
    {
      Index = index;
      IsCancel = isCancel;
    }

    public int Index { get; }
    public bool IsCancel { get; }
  }

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

    public static void WriteColor(string message, string color = Colors.txtDefault, bool isInline = false)
    {
      if (isInline)
        _colorify.Write(message, color);
      else
        _colorify.WriteLine(message, color);
    }

    public static void Clear()
    {
      Console.Clear();
    }

    public static ConsoleKey ReadKey()
    {
      return Console.ReadKey().Key;
    }

    public static void Pause(bool visible = true)
    {
      if (visible)
        WriteColor("\n계속하려면 아무 키나 누르세요");

      ReadKey();
    }

    public static int Ask(string title, List<string> query)
    {
      if (query.Count == 0)
        return -1;

      var i = 0;
      var done = false;

      do
      {
        Clear();
        WriteColor(title);
        for (int k = 0; k < query.Count; k++)
        {
          var txt = $"{k + 1}. {query[k]}";

          if (k == i)
            WriteColor(txt, Colors.txtDefault);
          else
            WriteColor(txt, Colors.txtMuted);
        }
        WriteColor("\n↑↓ 이동, ↲ 선택");
        var key = ReadKey();

        switch (key)
        {
          case ConsoleKey.DownArrow:
            if (i < query.Count - 1)
              i++;
            break;
          case ConsoleKey.UpArrow:
            if (i > 0)
              i--;
            break;
          case ConsoleKey.Enter:
            done = true;
            break;
        }
      } while (!done);

      return i;
    }

    public static AskResponse Ask(string title, List<string> query, bool addCancel)
    {
      if (addCancel)
      {
        query.Add("취소");
        var res = Ask(title, query);
        if (res == query.Count)
          return new AskResponse(-1, true);
        else
          return new AskResponse(res, false);
      }
      else
      {
        var res = Ask(title, query);
        return new AskResponse(res, false);
      }
    }

    public static string ReadLine(string query, Func<string?, bool> checker)
    {
      string? line;

      do
      {
        WriteColor($"{query}", Colors.txtDefault, true);
        line = Console.ReadLine();
      } while (!checker(line));

      if (line == null)
        return "";
      else
        return line;
    }
  }
}
