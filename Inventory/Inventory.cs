using Hoguma.Util;
using PumpkinGoguma.Item;

namespace PumpkinGoguma.Inventory
{
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

    }

    public SelectedItem? GetSelectedItem()
    {
      var invList = Items.Select(x => x.Type.ToString()).ToList<string>();

      while (true)
      {
        var res = ConsoleUtil.Ask("인벤토리 종류를 선택하세요.", invList, true);
        if (!res.IsCancel)
        {
          var itemType = ((ItemType)res.Index).ToString();
          var itemList = Items[res.Index].Items.Select(x => $"{x.Name} [ {x.Count} ]").ToList<string>();

          var itemRes = ConsoleUtil.Ask($"[ {itemType} ] 아이템을 선택하세요", itemList, true);

          if (!itemRes.IsCancel)
          {
            return new SelectedItem((ItemType)res.Index, itemRes.Index);
          }
          else
            return null;
        }
        else
          return null;
      }
    }
  }
}