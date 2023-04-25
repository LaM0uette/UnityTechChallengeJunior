using Builders;
using Data;
using UnityEngine;
using Utils;

namespace Controllers
{
    public class FurnitureManager : MonoBehaviour
    {
        [SerializeField] private Material _material;
        [SerializeField] private TextAsset[] _furnitureJsonFiles;
        private const float _spacingBetweenFurnitures = 100f;

        private void Start()
        {
            float xOffset = 0;

            foreach (var jsonFile in _furnitureJsonFiles)
            {
                var furnitureData = JsonParser.Parse<Furniture>(jsonFile.text);
                var builder = gameObject.AddComponent<FurnitureBuilder>().SetData(furnitureData);
                var furniture = builder.Build();
                
                ChangeFurnitureMaterial(furniture, _material);

                furniture.transform.position = new Vector3(furnitureData.width / 2 + xOffset, 0, 0);
                xOffset += furnitureData.width + _spacingBetweenFurnitures;
            }
        }
        
        private static void ChangeFurnitureMaterial(GameObject furniture, Material material)
        {
            var renderers = furniture.GetComponentsInChildren<Renderer>();

            foreach (var furnitureRenderer in renderers)
            {
                furnitureRenderer.material = material;
            }
        }
    }
}
