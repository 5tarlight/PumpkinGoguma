using Hoguma.Item;

namespace Hoguma.Terrain
{
  public interface ITerrain
  {
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract List<ITerrain> Neighbors { get; }
    public abstract int MovementCost { get; }
    public abstract TerrainType Type { get; }
    public abstract TerrainRequire isPassable { get; }
  }
}
