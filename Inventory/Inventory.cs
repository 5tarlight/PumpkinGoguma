using Colorify;
using Hoguma.Util;
using Hoguma.Item;

namespace Hoguma.Inventory
{
  [Serializable]
  public class Inventory
  {
    public List<InventoryItem> Items { get; set; } = new List<InventoryItem>();

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

      var select = ConsoleUtil.Select("아이템을 선택하세요.", new SelectQuery(invList, itemList));

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
        }
        else
        {
          ConsoleUtil.WriteLine($"{item.Name}(을)를 버리지 않았습니다.");
          return;
        }
      }

      Items[(int)selectedItem.Type].Items.RemoveAt(selectedItem.Index);
    }
  }
}