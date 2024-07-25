using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 50;
    public float currentHealth;
    public PlayerHUD playerHUD;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        playerHUD.healthBar.fillAmount = currentHealth / maxHealth;

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
