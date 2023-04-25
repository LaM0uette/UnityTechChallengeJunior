using Constants;
using UnityEngine;

namespace Camera
{
    public class MoveFixture : MonoBehaviour
    {
        [SerializeField] private Material _material;
        [SerializeField] private Material _materialSelected;
        
        private UnityEngine.Camera mainCamera;
        private GameObject selectedFixture;
        
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

                    if (hitObject.CompareTag(Tags.Fixture)) {
                        selectedFixture = hitObject;
                        selectedFixture.GetComponent<Renderer>().material = _materialSelected;
                    } else if (selectedFixture != null && hitObject.CompareTag(Tags.Floor)) {
                        selectedFixture.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
                        selectedFixture.GetComponent<Renderer>().material = _material;
                    }
                }
            }
        }
    }
}
