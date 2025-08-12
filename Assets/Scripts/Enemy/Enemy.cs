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

    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
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
        }
    }
    protected void ReachedEnd()
    {
        animator.SetBool(animatorParam_IsWalking, false);
        GameManager.Instance.playerHealth.TakeDamage(damage);
        GameManager.Instance.AddScore(0);
        Destroy(gameObject);

    }
}
