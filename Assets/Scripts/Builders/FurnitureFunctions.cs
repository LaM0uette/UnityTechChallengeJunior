using UnityEngine;

namespace Builders
{
    public static class FurnitureFunctions
    {
        public static GameObject CreateCube() => GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        public static void SetTansform(this GameObject gameObject, Vector3 position = new Vector3(), Vector3 scale = new Vector3())
        {
            gameObject.transform.position = position;
            gameObject.transform.localScale = scale;
        }

        public static void AddMeshCollider(this GameObject gameObject) => gameObject.AddComponent<MeshCollider>();

        public static void AddChild(this GameObject parent, GameObject child) => child.transform.SetParent(parent.transform);
        
        public static void SetTagForChildren(this GameObject parent, string tagName)
        {
            foreach (Transform child in parent.transform)
            {
                child.gameObject.tag = tagName;
            }
        }
        
        public static void ChangeFixturesMaterial(this GameObject furniture, Material material)
        {
            var renderers = furniture.GetComponentsInChildren<Renderer>();

            foreach (var furnitureRenderer in renderers)
            {
                furnitureRenderer.material = material;
            }
        }
    }
}
