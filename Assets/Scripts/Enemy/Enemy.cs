using System.Linq;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Transform endPoint;
    [SerializeField] private string animatorParam_IsWalking;

    [SerializeField] private int damage;
    [SerializeField] public float speed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private int currencyDropped;

    private WaveManager waveManager;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        waveManager = FindAnyObjectByType<WaveManager>();
    }
    protected virtual void Start()
    {
        animator.SetBool(animatorParam_IsWalking, true);
    }

    public void Initialize(Transform inputEndPoint)
    {
        endPoint = inputEndPoint;
        SetDestination(endPoint);
    }
    protected abstract void SetDestination(Transform endPoint);
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            GameManager.Instance.AddScore(currencyDropped);
            
            Destroy(gameObject);
            CheckEnemies();
        }
    }
    private void CheckEnemies()
    {
        Enemy[] all = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        int enemyCount = all.Count();
        if (waveManager.WaveOver = true && enemyCount <= 1)
        {
            GameManager.Instance.YouWin();
        }
    }
    protected void ReachedEnd()
    {
        animator.SetBool(animatorParam_IsWalking, false);
        GameManager.Instance.playerHealth.TakeDamage(damage);
        
        Destroy(gameObject);
        CheckEnemies();

    }
}
