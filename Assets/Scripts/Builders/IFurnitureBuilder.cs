using Data;
using UnityEngine;

namespace Builders
{
    public interface IFurnitureBuilder
    {
        IFurnitureBuilder SetData(Furniture furnitureData);
        GameObject Build();
    }
}
