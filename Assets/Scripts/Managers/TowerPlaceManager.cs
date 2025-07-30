using UnityEngine;
using UnityEngine.InputSystem;

public class TowerPlaceManager : MonoBehaviour
{
    public Camera MainCamera;
    public LayerMask TileLayer;
    public InputAction PlaceTowerAction;

    [SerializeField] private float towerPlacementHeightOffset = .2f;
    private GameObject currentTowerToSpawn;
    private GameObject towerPreview;
    private Vector3 towerPlacementPosition;

    [SerializeField] private bool isPlacingTower = false;
    private bool isTileSelected = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlacingTower)
        {
            Ray ray = MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if(Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, TileLayer))
            {
                towerPlacementPosition = hitInfo.transform.position + Vector3.up * towerPlacementHeightOffset;
                towerPreview.transform.position = towerPlacementPosition;
                towerPreview.SetActive(true);
                isTileSelected = true;
            }
            else
            {
                towerPreview.SetActive(false);
                isTileSelected=false;
            }
        }
    }

    private void OnEnable()
    {
        PlaceTowerAction.Enable();
        PlaceTowerAction.performed += OnPlaceTower;
    }

    private void OnDisable()
    {
        PlaceTowerAction.Disable();
        PlaceTowerAction.performed -= OnPlaceTower;
    }
    public void StartPlacingTower(GameObject towerPrefab)
    {
        if (currentTowerToSpawn != towerPrefab)
        {
            isPlacingTower = true;
            currentTowerToSpawn = towerPrefab;
            towerPreview = Instantiate(currentTowerToSpawn);
            if(towerPreview != null)
            {
                Destroy(towerPreview);
            }
        }
        
    }
    private void OnPlaceTower(InputAction.CallbackContext context)
    {
        if (isPlacingTower && isTileSelected)
        {
            isPlacingTower = false;
            Instantiate(currentTowerToSpawn, towerPlacementPosition, Quaternion.identity);
            Destroy(towerPreview);
            currentTowerToSpawn = null;
        }
        
    }
}
