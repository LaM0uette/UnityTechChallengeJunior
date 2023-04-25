using Constants;
using UnityEngine;

namespace Camera
{
    public class MoveFixture : MonoBehaviour
    {
        #region Statements

        [Header("Materials")]
        [SerializeField] private Material fixtureMaterial;
        [SerializeField] private Material fixtureMaterialSelected;
        
        private UnityEngine.Camera _mainCamera;
        private GameObject _selectedFixture;
        private Renderer _selectedFixtureRenderer;

        #endregion

        #region Events

        private void Start()
        {
            _mainCamera = UnityEngine.Camera.main;
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnLeftClick();
            }
        }

        #endregion
        
        #region Functions

        private void OnLeftClick()
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit, Mathf.Infinity)) return;
            
            var hitObject = hit.transform.gameObject;

            if (hitObject.CompareTag(Tags.Fixture))
            {
                SetSelectedFixture(hitObject);
                SetFixtureMaterial(fixtureMaterialSelected);
            } else if (_selectedFixture != null && hitObject.CompareTag(Tags.Floor))
            {
                MoveFixtureToFloor(hit);
                SetFixtureMaterial(fixtureMaterial);
            }
        }

        private void SetSelectedFixture(GameObject fixture)
        {
            _selectedFixture = fixture;
            _selectedFixtureRenderer = _selectedFixture.GetComponent<Renderer>();
        }

        private void SetFixtureMaterial(Material material)
        {
            _selectedFixtureRenderer.material = material;
        }

        private void MoveFixtureToFloor(RaycastHit hit)
        {
            _selectedFixture.transform.position = new Vector3(hit.point.x, _selectedFixtureRenderer.bounds.size.y / 2, hit.point.z);
        }

        #endregion
    }
}
