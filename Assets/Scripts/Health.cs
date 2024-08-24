using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 50;
    public float currentHealth;
    public float healthPercent;
    public GameObject coinSpawnObject;

    public AudioClip deathSound; 
    private AudioSource _audioSource; 

    void Start()
    {
        if (GameController.instance != null && CompareTag("Player"))
        {
            currentHealth = GameController.instance.playerCurrentHealth;
        }
        else
        {
            currentHealth = maxHealth;
        }
        healthPercent = currentHealth / maxHealth;

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        healthPercent = currentHealth / maxHealth;

        if (GameController.instance != null && CompareTag("Player"))
        {
            GameController.instance.playerCurrentHealth = currentHealth;
        }

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
            if (deathSound != null && _audioSource != null)
            {
                _audioSource.PlayOneShot(deathSound);
            }

            Destroy(gameObject);
            Instantiate(coinSpawnObject, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

}
