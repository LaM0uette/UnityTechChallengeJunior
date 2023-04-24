using Builders;
using Data;
using UnityEngine;
using Utils;

namespace Controllers
{
    public class FurnitureManager : MonoBehaviour
    {
        [SerializeField] private string jsonFilePath;

        private void Start(){
            var furnitureData = JsonParser.ReadAndParse<Furniture>(Application.dataPath + jsonFilePath);
            var builder = gameObject.AddComponent<FurnitureBuilder>().SetData(furnitureData);
            var furniture = builder.Build();
            
            furniture.transform.SetParent(transform);
        }
    }
}