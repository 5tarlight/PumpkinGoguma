using Hoguma.Item;

namespace Hoguma.Terrain
{
  public interface IItemRequiredTerrain
  {
    public abstract List<IItem> RequiredItems { get; }
  }
}
