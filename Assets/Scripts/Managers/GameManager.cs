using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Health playerHealth;
    public int Money;
    [SerializeField] private TMP_Text MoneyAmount;
    [SerializeField] private GameObject GameOverObject;
    [SerializeField] private GameObject YouWinObject;
    [SerializeField] private GameObject SpawnButton;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        playerHealth = GetComponent<Health>();
        AddScore(50);
        SpawnButton.SetActive(true);
        YouWinObject.SetActive(false);
        GameOverObject.SetActive(false);
    }
    public void GameOver()
    {
        GameOverObject.SetActive(true);
    }
    public void YouWin()
    {
        YouWinObject.SetActive(true);
    }
    public void SpawnStart()
    {
        SpawnButton.SetActive(false);
    }
    public void AddScore(int currencyDrop)
    {
        Money += currencyDrop;
        MoneyAmount.text = Money.ToString();
    }

    
}
