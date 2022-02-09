using Colorify;
using Hoguma.Util;
using Hoguma.Item;

namespace Hoguma.Inventory
{
  [Serializable]
  public class Inventory
  {
    public List<InventoryItem> Items { get; private set; } = new List<InventoryItem>();

    public EquipmentInv Equipment { get; private set; } = new EquipmentInv();

    public const int MaxMoney = Int32.MaxValue;

    public int Money { get; private set; }

    public Inventory()
    {
      var typeCount = Enum.GetValues(typeof(ItemType)).Length;

      for (var i = 0; i < typeCount; i++)
      {
        Items.Add(new InventoryItem((ItemType)i));
      }
    }

    public void Show()
    {
      while (true)
      {
        var res = GetSelectedItem();
        if (res != null)
        {
          ShowDescription((SelectedItem)res);
        }
        else return;
      }
    }

    public SelectedItem? GetSelectedItem()
    {
      var invList = Items.Select(x => x.Type.ToString()).ToList<string>();
      var itemList = new List<List<string>>();

      foreach (var inv in Items)
      {
        itemList.Add(inv.Items.Select(x => x.Name).ToList());
      }

      var len = 2 + (invList.Count * 3);
      foreach (var inv in invList) len += inv.Length;

      var select = ConsoleUtil.Select(() =>
      {
        ConsoleUtil.WriteColor(ConsoleUtil.GetSep(len, " INVENTORY "));
        ConsoleUtil.WriteColor(ConsoleUtil.GetSep(len, $"{Money} G", ' '), Colors.txtWarning);
      }, new SelectQuery(invList, itemList));

      if (select.IsCancel) return null;
      else return new SelectedItem((ItemType)select.Row, select.Column);

    }

    public void ShowDescription(SelectedItem selectedItem)
    {
      var item = Items[(int)selectedItem.Type].Items[selectedItem.Index];

      ConsoleUtil.WriteColor($" - {item.Name}", Colors.txtInfo, true);
      ConsoleUtil.WriteColor($"{item.Type.ToString()} 아이템", Colors.txtWarning);
      ConsoleUtil.WriteColor($" [ {item.Count} 개 ]", Colors.txtDefault, true);
      ConsoleUtil.WriteLine(item.Description);

      ConsoleUtil.Pause(false);

    }

    public void RemoveItem(SelectedItem selectedItem, bool ask = true)
    {
      var item = Items[(int)selectedItem.Type].Items[selectedItem.Index];

      if (ask)
      {
        int count = 1;
        if (item.Count > 1)
        {
          ConsoleUtil.ReadLine($"{item.Name}(이)가 {item.Count}개가 있습니다. 몇 개를 버리시겠습니까?", s =>
          {
            int i;
            var isParse = Int32.TryParse(s, out i);
            if (isParse)
            {
              if (i > 0 || i <= item.Count)
              {
                count = i;
                return true;
              }
            }
            return false;
          });
        }

        var res = ConsoleUtil.Ask($"{item.Name}{(count == 1 ? "(을)를" : $" {item.Count}개를")} 버리시겠습니까", new List<string>() { "예", "아니요" });
        if (res == 0)
        {
          ConsoleUtil.WriteLine($"{item.Name}{(count == 1 ? "(을)를" : $" {item.Count}개를")} 버렸습니다.");
          ConsoleUtil.Pause(false);
        }
        else
        {
          ConsoleUtil.WriteLine($"{item.Name}(을)를 버리지 않았습니다.");
          ConsoleUtil.Pause(false);
          return;
        }
      }

      Items[(int)selectedItem.Type].Items.RemoveAt(selectedItem.Index);
    }

    public void GetItem(IItem item, bool printMessage = true)
    {
      var inv = Items[Items.IndexOf(Items.Single(x => x.Type == item.Type))];

      var mergeableItem = inv.Items.SingleOrDefault(x => x.CanMerge(item));

      if (mergeableItem != null)
      {
        inv.Items[inv.Items.IndexOf(mergeableItem)].Count += item.Count;
      }
      else
      {
        inv.Items.Add(item);
      }

      if (printMessage)
      {
        ConsoleUtil.WriteColor($"{item.Name}{(item.Count == 1 ? "(을)를" : $" {item.Count}개를")} 획득했습니다.", Colors.txtSuccess);
        ConsoleUtil.Pause(false);
      }
    }

    public void GetMoney(int value) => Money = Math.Min(Money + Math.Abs(value), MaxMoney);

    public void LoseMoney(int value) => Money = Math.Max(0, Money - Math.Abs(value));
  }
}