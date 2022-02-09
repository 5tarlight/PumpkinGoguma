using System.Net.NetworkInformation;
using System.Reflection;

namespace Hoguma.Item
{
  [Serializable]
  public abstract class Item : IItem, ICloneable
  {
    public abstract string Name { get; }

    public abstract string Description { get; }

    public int Count { get; set; } = 1;

    public abstract ItemType Type { get; }

    public virtual ItemId Id => ItemId.NONE;

    public object Clone()
    {
      object newInstance = Activator.CreateInstance(this.GetType());
      PropertyInfo[] properties = newInstance.GetType().GetProperties();

      int i = 0;

      foreach (var property in this.GetType().GetProperties())
      {
        properties[i].SetValue(newInstance, property.GetValue(this, null), null);
        i++;
      }
      return newInstance;
    }

    public virtual bool CanMerge(IItem item) => Id == item.Id;
  }
}