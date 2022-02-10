using Colorify;
using Colorify.UI;
using System;
using System.Collections.Generic;
using System.Text;

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
        _colorify.Write(message + "\n", color);

    }

    public static void Clear()
    {
      _colorify.Clear();
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

    public static AskResponse Ask(string title, List<string> query, bool isCancel = false) => Ask(() => { WriteColor($"\n{title}\n"); }, query, isCancel);

    public static AskResponse Ask(Action title, List<string> queryParam, bool isCancel = false)
    {
      var query = queryParam.ToArray();
      if (query.Length == 0)
        return new AskResponse(-1, true);

      var i = 0;
      var done = false;

      do
      {
        Clear();
        title();
        for (int k = 0; k < query.Length; k++)
        {
          var txt = $"{k + 1}. {query[k]}";

          if (k == i)
            WriteColor(txt, Colors.txtDefault);
          else
            WriteColor(txt, Colors.txtMuted);
        }
        WriteColor("\n" + Keybinds.Marks(true, false, true, isCancel));
        var key = Keybinds.Check(ReadKey());

        switch (key)
        {
          case KeyType.DOWN:
            if (i == query.Length - 1) i = 0;
            else i++;
            break;
          case KeyType.UP:
            if (i == 0) i = query.Length - 1;
            else i--;
            break;
          case KeyType.ENTER:
            done = true;
            break;
          case KeyType.CANCEL:
            if (isCancel) return new AskResponse(-1, true);
            break;
        }
      } while (!done);

      return new AskResponse(i, false);
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

    public static SelectResponse Select(Action title, SelectQuery query, bool isCancel = false) => Select(title, query, () => { }, isCancel);

    public static SelectResponse Select(Action title, SelectQuery query, Action middle, bool isCancel = false)
    {
      const int max = 10;
      var page = 0;

      var selectedRow = 0;
      var selectedColumn = 0;
      do
      {
        Clear();
        title();
        WriteColor("| ", Colors.txtDefault, true);

        for (var i = 0; i < query.Rows.Count; i++)
        {
          WriteColor(query.Rows[i], (selectedRow == i ? Colors.txtDefault : Colors.txtMuted), true);
          WriteColor(" | ", Colors.txtDefault, true);
        }

        Write("\n");
        middle();
        Write("\n");

        for (var i = 0; i < max; i++)
        {
          var index = (max * page) + i;
          if (index <= query.Columns[selectedRow].Count - 1)
          {
            var txt = $"    {index + 1}. {query.Columns[selectedRow][index]}";
            WriteColor(txt, (i == selectedColumn ? Colors.txtDefault : Colors.txtMuted));
          }
          else
          {
            var txt = $"    {index + 1}. 없음";
            WriteColor(txt, (i == selectedColumn ? Colors.txtDefault : Colors.txtMuted));
          }
        }
        WriteColor("\n" + Keybinds.Marks(true, true, true, isCancel));

        var pageCount = (int)Math.Ceiling((double)(query.Columns[selectedRow].Count / max));
        var key = Keybinds.Check(ReadKey());

        switch (key)
        {
          case KeyType.LEFT:
            if (selectedRow == 0)
              selectedRow = query.Rows.Count - 1;
            else
              selectedRow--;
            break;
          case KeyType.RIGHT:
            if (selectedRow == query.Rows.Count - 1)
              selectedRow = 0;
            else
              selectedRow++;
            break;
          case KeyType.UP:
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
          case KeyType.DOWN:
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
          case KeyType.CANCEL:
            if (isCancel) return new SelectResponse(-1, -1, true);
            break;
          case KeyType.ENTER:
            var index = (max * page) + selectedColumn;
            if (index < query.Columns[selectedRow].Count)
              return new SelectResponse(selectedRow, (max * page) + selectedColumn, false);
            break;
        }
      } while (true);
    }

    public static string GetSep(int length, string txt = "", char chr = '=')
    {
      var sb = new StringBuilder();

      if (txt == "")
      {
        for (var i = 0; i < length; i++) sb.Append(chr);
      }
      else if (txt.Length % 2 == 0)
      {
        var l = (length - txt.Length) / 2 - 1;
        for (var i = 0; i < l; i++) sb.Append(chr);
        sb.Append($" {txt} ");
        for (var i = 0; i < l; i++) sb.Append(chr);
      }
      else
      {
        var l = (length - txt.Length - 1) / 2 - 1;
        for (var i = 0; i < l; i++) sb.Append(chr);
        sb.Append($" {txt} ");
        for (var i = 0; i < l + 1; i++) sb.Append(chr);
      }

      return sb.ToString();
    }

    public static bool AskBool(string query) => AskBool(() => { WriteColor(query); });

    public static bool AskBool(Action query)
    {
      while (true)
      {
        Clear();
        query();
        WriteColor(Keybinds.Marks(false, false, true, true));
        var key = Keybinds.Check(ReadKey());

        if (key == KeyType.ENTER) return true;
        else if (key == KeyType.CANCEL) return false;
      }
    }

    public static void Information(string text) => Information(() => { WriteColor(text); });

    public static void Information(Action text)
    {
      Clear();
      Write("\n\n");
      text();
      Write("\n\n");
      Pause(false);
    }

    public static AskResponse Ask(string title, List<string> query, List<Action> responses, bool isCancel = false)
    {
      return Ask(
        () => { WriteColor($"\n{title}\n"); },
        query,
        responses,
        isCancel
      );
    }

    public static AskResponse Ask(Action title, List<string> query, List<Action> responses, bool isCancel = false)
    {
      var res = Ask(title, query, isCancel);

      if (res.IsCancel)
        return res;

      try
      {
        responses[res.Index]();
        return res;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return res;
      }
    }
  }
}
