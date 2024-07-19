using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        if (currentHealth == 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }

    void Die()
    {
        if (CompareTag("Player"))
        {
            if (GameController.instance != null)
            {
                GameController.instance.GameOver();
            }
            else
            {
                Debug.LogError("GameController instance is null.");
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
