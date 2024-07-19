using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public Health playerHealth;
    public Text healthText;

    void Update()
    {
        healthText.text = "HP: " + playerHealth.currentHealth;
    }
}
