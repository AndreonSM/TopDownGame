using UnityEngine;
using UnityEngine.UI;

public class LifeHUD : MonoBehaviour
{
    public Health playerHealth;
    public Image healthBar;
    public Text healthText;

    void Update()
    {
        healthText.text = "HP: " + playerHealth.currentHealth;
        healthBar.fillAmount = playerHealth.healthPercent;
    }


}
