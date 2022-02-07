using Hoguma.Util;

namespace Hoguma.Game
{
  public class Main
  {

    public static void ShowMenu()
    {
      while (true)
      {
        var list = new List<string>()
        {
          "인벤토리 열기", "게임 종료"
        };
        var res = ConsoleUtil.Ask("무엇을 하시겠습니까?", list);
        switch (res)
        {
          case 0:
            PlayerManager.CurrentChampion.Inventory.Show();
            break;
        }
      }
    }
  }
}