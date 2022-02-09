using System.Linq;
using System.Text;
namespace Hoguma.Util
{
  public enum KeyType
  {
    ENTER, CANCEL, UP, DOWN, LEFT, RIGHT
  }
  public class Key
  {
    public KeyType Type { get; set; }
    public ConsoleKey[] Keys { get; set; }
    public string Mark { get; set; }

    public Key(KeyType type, string mark, ConsoleKey[] keys)
    {
      Type = type;
      Keys = keys;
      Mark = mark;
    }

    public bool Check(ConsoleKey key) => Keys.Any(x => x == key);
  }

  public class Keys
  {
    public List<Key> Items { get; set; }

    public Key this[KeyType type]
    {
      get => Items.Single(x => x.Type == type);
      set => Items[Items.IndexOf(Items.Single(x => x.Type == type))] = value;
    }

    public Keys(Key[] key)
    {
      Items = key.ToList();
    }
  }

  public class Keybinds
  {
    public static Keys Keys { get; set; } = new Keys(new Key[]
    {
      new Key(KeyType.ENTER, "Z", new ConsoleKey[] { ConsoleKey.Enter, ConsoleKey.Z }),
      new Key(KeyType.CANCEL, "X", new ConsoleKey[] { ConsoleKey.Escape, ConsoleKey.X }),
      new Key(KeyType.UP, "↑", new ConsoleKey[] { ConsoleKey.UpArrow }),
      new Key(KeyType.DOWN, "↓", new ConsoleKey[] { ConsoleKey.DownArrow }),
      new Key(KeyType.LEFT, "←", new ConsoleKey[] { ConsoleKey.LeftArrow }),
      new Key(KeyType.RIGHT, "→", new ConsoleKey[] { ConsoleKey.RightArrow }),
    });

    public static string Marks(bool upDown = true, bool leftRight = false, bool enter = true, bool cancel = false)
    {
      var sb = new StringBuilder();
      if (upDown) sb.Append($"{Keys[KeyType.UP].Mark} {Keys[KeyType.DOWN].Mark}");
      if (leftRight) sb.Append($" {Keys[KeyType.LEFT].Mark} {Keys[KeyType.RIGHT].Mark}");
      sb.Append(". 이동 ");
      if (enter) sb.Append($"{Keys[KeyType.ENTER].Mark}. 확인 ");
      if (cancel) sb.Append($"{Keys[KeyType.CANCEL].Mark}. 취소");
      return sb.ToString();
    }

    public static KeyType? Check(ConsoleKey key)
    {
      var check = Keys.Items.SingleOrDefault(x => x.Check(key));
      if (check != null) return check.Type;
      else return null;
    }

  }
}