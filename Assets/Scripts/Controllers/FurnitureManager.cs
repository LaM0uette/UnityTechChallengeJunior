using Builders;
using Data;
using UnityEngine;
using Utils;

namespace Controllers
{
    public class FurnitureManager : MonoBehaviour
    {
        [SerializeField] private TextAsset[] _furnitureJsonFiles;
        [SerializeField] private float _spacingBetweenFurnitures = 1.0f;

        private void Start()
        {
            float xOffset = 0;

            foreach (var jsonFile in _furnitureJsonFiles)
            {
                var furnitureData = JsonParser.Parse<Furniture>(jsonFile.text);
                var builder = gameObject.AddComponent<FurnitureBuilder>().SetData(furnitureData);
                var furniture = builder.Build();

                furniture.transform.position = new Vector3(xOffset, 0, 0);
                xOffset += furnitureData.width + _spacingBetweenFurnitures;
            }
        }
    }
}
