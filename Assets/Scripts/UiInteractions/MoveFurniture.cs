using Constants;
using UnityEngine;

namespace UiInteractions
{
    public class MoveFurniture : MonoBehaviour
    {
        #region Statements

        [Header("Materials")]
        [SerializeField] private Material fixtureMaterial;
        [SerializeField] private Material fixtureMaterialSelected;
        
        private Camera _mainCamera;
        private GameObject _selectedFurniture;
        private Renderer[] _selectedFixturesRenderer;

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
            
            var furnitureParent = hitObject.gameObject.transform.parent.gameObject;

            if (_selectedFurniture != null && furnitureParent.CompareTag(Tags.Furniture))
            {
                SetFixturesMaterial(fixtureMaterial);
                ResetFixture();
            }
            
            if (furnitureParent.CompareTag(Tags.Furniture))
            {
                SetFurniture(furnitureParent);
            } else if (_selectedFurniture != null && hitObject.gameObject.CompareTag(Tags.Floor))
            {
                Move(hitObject.hit);
            }
        }

        private (bool isGameObject, GameObject gameObject, RaycastHit hit) GetHitObject()
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            return !Physics.Raycast(ray, out var hit, Mathf.Infinity) 
                ? (false, null, hit) 
                : (true, hit.transform.gameObject, hit);
        }

        private void SetFurniture(GameObject parent)
        {
            _selectedFurniture = parent;
            SetFixturesRenderer();
            SetFixturesMaterial(fixtureMaterialSelected);
        }

        private void SetFixturesRenderer()
        {
            _selectedFixturesRenderer = _selectedFurniture.GetComponentsInChildren<Renderer>();
        }

        private void SetFixturesMaterial(Material material)
        {
            foreach (var fixtureRenderer in _selectedFixturesRenderer)
            {
                fixtureRenderer.material = material;
            }
        }

        private void Move(RaycastHit hit)
        {
            MoveOnFloor(hit);
            SetFixturesMaterial(fixtureMaterial);
            ResetFixture();
        }

        private void MoveOnFloor(RaycastHit hit)
        {
            _selectedFurniture.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
        }

        private void ResetFixture()
        {
            _selectedFurniture = null;
            _selectedFixturesRenderer = null;
        }

        #endregion
    }
}
