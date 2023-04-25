using Builders;
using Data;
using UnityEngine;
using Utils;

namespace Controllers
{
    public class FurnitureManager : MonoBehaviour
    {
        #region Statements
        
        [Header("Materials")]
        [SerializeField] private Material fixtureMaterial;
        
        [Header("Furnitures")]
        [SerializeField] private TextAsset[] furnitureJsonFiles;
        [SerializeField] private float spacingBetweenFurnitures = 100f;

        #endregion

        #region Functions

        private void Start()
        {
            float xOffset = 0;

            foreach (var jsonFile in furnitureJsonFiles)
            {
                var furnitureData = JsonParser.Parse<Furniture>(jsonFile.text);
                var builder = gameObject.AddComponent<FurnitureBuilder>().SetData(furnitureData);
                var furniture = builder.Build();
                
                furniture.ChangeFixturesMaterial(fixtureMaterial);
                furniture.transform.position = new Vector3(furnitureData.width / 2 + xOffset, 0, 0);
                
                xOffset += furnitureData.width + spacingBetweenFurnitures;
            }
        }

        #endregion
    }
}
