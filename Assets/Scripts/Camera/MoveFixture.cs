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
            var hitObject = GetHitObject();
            
            if (!hitObject.isGameObject) return;

            if (_selectedFixture != null && hitObject.gameObject.CompareTag(Tags.Fixture))
            {
                SetFixtureMaterial(fixtureMaterial);
                
                _selectedFixture = hitObject.gameObject;
                SetFixtureRenderer(hitObject.gameObject);
                SetFixtureMaterial(fixtureMaterialSelected);
            } else if (hitObject.gameObject.CompareTag(Tags.Fixture))
            {
                _selectedFixture = hitObject.gameObject;
                SetFixtureRenderer(hitObject.gameObject);
                SetFixtureMaterial(fixtureMaterialSelected);
            } else if (_selectedFixture != null && hitObject.gameObject.CompareTag(Tags.Floor))
            {
                MoveFixtureToFloor(hitObject.hit);
                SetFixtureMaterial(fixtureMaterial);
                ResetFixture();
            }
        }

        private (bool isGameObject, GameObject gameObject, RaycastHit hit) GetHitObject()
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            return !Physics.Raycast(ray, out var hit, Mathf.Infinity) 
                ? (false, null, hit) 
                : (true, hit.transform.gameObject, hit);
        }

        private void SetFixtureRenderer(GameObject fixture)
        {
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

        private void ResetFixture()
        {
            _selectedFixture = null;
            _selectedFixtureRenderer = null;
        }

        #endregion
    }
}
