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
          },
          new List<Action>() {
          () => { player.Inventory.Show(); },
          () => {
              player.Inventory.GetItem(new TestItemE());
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
