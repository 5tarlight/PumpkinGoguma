using Hoguma.Item;
using Hoguma.Util;

namespace Hoguma.Game
{
  public class Main
  {
    public static void ShowMenu()
    {
      var player = PlayerManager.CurrentChampion;
      while (true)
      {
        ConsoleUtil.Ask(
          () => { ConsoleUtil.WriteColor("무엇을 하시겠습니까?"); },
          new List<string>() {
            "인벤토리 열기",
            "테스트 아이템 받기",
            "돈 받기",
            "게임 종료",
            player.Inventory.Items[0].Items.Count.ToString(),
            player.Inventory.Items[1].Items.Count.ToString(),
            player.Inventory.Items[2].Items.Count.ToString(),
          },
          new List<Action>() {
          () => { player.Inventory.Show(); },
          () => {
              // PlayerManager.CurrentChampion.Inventory.GetItem(new TestItemE());
              ConsoleUtil.WriteColor($"{player.Inventory.Items[0].Items.Count}");
              player.Inventory.Items[0].Items.Add(new TestItemE());
              ConsoleUtil.WriteColor($"{player.Inventory.Items[0].Items.Count}");
              ConsoleUtil.Pause();
              // player.Inventory.Items[0].Items.Add(new TestItemE());
              // player.Inventory.Items[1].Items.Add(new TestItemC());
              // player.Inventory.Items[2].Items.Add(new TestItemO());
            },
            () => {
              PlayerManager.CurrentChampion.Inventory.GetMoney(100);
              // player.Inventory.Money += 100;
            },
            () => { Environment.Exit(0); }
          }
        );

        // var list = new List<string>()
        // {
        //   "인벤토리 열기", "get test item", "게임 종료"
        // };
        // var res = ConsoleUtil.Ask("무엇을 하시겠습니까?", list);
        // switch (res.Index)
        // {
        //   case 0: // show player's inventory
        //     player.Inventory.Show();
        //     break;
        //   case 1: // get test item
        //     player.Inventory.Items[0].Items.Add(new TestItemE());
        //     // player.Inventory.Items[1].Items.Add(new TestItemC());
        //     player.Inventory.Items[2].Items.Add(new TestItemO());
        //     break;
        //   default: // exit
        //     Environment.Exit(0);
        //     break;
        // }
      }
    }
  }
}
