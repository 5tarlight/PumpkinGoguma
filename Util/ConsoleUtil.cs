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

  class SelectResponse
  {
    public SelectResponse(int row, int column, bool isCancel)
    {
      Row = row;
      Column = column;
      IsCancel = isCancel;
    }

    public int Row { get; }
    public int Column { get; }
    public bool IsCancel { get; }
  }

  class SelectQuery
  {
    public SelectQuery(List<string> rowItems, List<List<string>> columnItems)
    {
      Rows = rowItems;
      Columns = columnItems;
    }

    public List<string> Rows { get; }
    public List<List<string>> Columns { get; }
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
      var tmp = query.ConvertAll(q => q);
      if (addCancel)
      {
        tmp.Add("취소");
        var res = Ask(title, tmp);
        if (res == tmp.Count)
          return new AskResponse(-1, true);
        else
          return new AskResponse(res, false);
      }
      else
      {
        var res = Ask(title, tmp);
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

    public static SelectResponse Select(string title, SelectQuery query)
    {
      const int max = 10;
      var page = 0;

      var selectedRow = 0;
      var selectedColumn = 0;
      do
      {
        Clear();
        WriteColor(title, Colors.txtDefault, true);
        WriteColor("\n | ", Colors.txtDefault, true);

        for (var i = 0; i < query.Rows.Count; i++)
        {
          WriteColor(query.Rows[i], (selectedRow == i ? Colors.txtDefault : Colors.txtMuted), true);
          WriteColor(" | ", Colors.txtDefault, true);
        }
        Write("\n\n");

        for (var i = 0; i < max; i++)
        {
          var index = (max * page) + i;
          var txt = $"{index + 1}. {query.Columns[selectedRow][index]}";

          WriteColor(txt, (i == selectedColumn ? Colors.txtDefault : Colors.txtMuted));
        }
        WriteColor("\n↑↓←→ 이동, ↲ 선택, Esc 취소");

        var pageCount = (int)Math.Ceiling((double)(query.Columns[selectedRow].Count / max));
        var key = ReadKey();

        switch (key)
        {
          case ConsoleKey.LeftArrow:
            if (selectedRow == 0)
              selectedRow = query.Rows.Count - 1;
            else
              selectedRow--;
            break;

          case ConsoleKey.RightArrow:
            if (selectedRow == query.Rows.Count - 1)
              selectedRow = 0;
            else
              selectedRow++;
            break;

          case ConsoleKey.UpArrow:
            if (selectedColumn == 0)
            {
              if (page == 0)
                page = pageCount;
              else
                page--;
              selectedColumn = max - 1;
            }
            else
              selectedColumn--;
            break;

          case ConsoleKey.DownArrow:
            if (selectedColumn == max - 1)
            {
              if (page == pageCount)
                page = 0;
              else
                page++;
              selectedColumn = 0;
            }
            else
              selectedColumn++;

            break;

          case ConsoleKey.Escape:
            return new SelectResponse(-1, -1, true);

          case ConsoleKey.Enter:
            return new SelectResponse(selectedRow, selectedColumn, false);

        }
      } while (true);
    }
  }
}
