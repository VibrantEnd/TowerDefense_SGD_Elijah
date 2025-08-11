using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerPlaceManager : MonoBehaviour
{
    public Camera MainCamera;
    public LayerMask TileLayer;
    public InputAction PlaceTowerAction;

    [SerializeField] private GameObject InsufficientFunds;
    [SerializeField] private float towerPlacementHeightOffset = .2f;
    private GameObject currentTowerToSpawn;
    private GameObject towerPreview;
    private Vector3 towerPlacementPosition;

    [SerializeField] private bool isPlacingTower = false;
    private bool isTileSelected = false;
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
    IEnumerator IFundsCountDown()
    {
        yield return new WaitForSeconds(.5f);
        InsufficientFunds.SetActive(false);
    }
    public void StartPlacingTower(GameObject towerPrefab)
    {
        if(towerPrefab.GetComponent<Tower>().Cost > GameManager.Instance.Money)
        {
            InsufficientFunds.SetActive(true);
            StartCoroutine(IFundsCountDown());
        }
        if (currentTowerToSpawn != towerPrefab && towerPrefab.GetComponent<Tower>().Cost <= GameManager.Instance.Money)
        {
            if (towerPreview != null)
            {
                Destroy(towerPreview);
            }
            isPlacingTower = true;
            currentTowerToSpawn = towerPrefab;
            towerPreview = Instantiate(currentTowerToSpawn);
            towerPreview.GetComponent<Tower>().IsBeingPlaced = true;

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
            towerPreview.GetComponent<Tower>().IsBeingPlaced = false;
            towerPreview.GetComponent<Tower>().Buy();
        }
        
    }
}
