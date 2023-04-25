using UnityEngine;

namespace Camera
{
    public class MoveFixture : MonoBehaviour
    {
        private UnityEngine.Camera mainCamera;
        
        private void Start()
        {
            mainCamera = UnityEngine.Camera.main;
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
                {
                    var hitObject = hit.transform.gameObject;

                    if (hitObject != null)
                    {
                        Debug.Log("Parent object: " + hitObject.name);
                    }
                }
            }
        }
    }
}
