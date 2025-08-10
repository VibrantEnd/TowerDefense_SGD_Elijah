using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Health playerHealth;
    public int Money;
    [SerializeField] private TMP_Text MoneyAmount;

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
    }
    public void AddScore(int currencyDrop)
    {
        Money += currencyDrop;
        MoneyAmount.text = Money.ToString();
    }

    
}
