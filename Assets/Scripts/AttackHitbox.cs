using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public int damage = 5;
    public float knockbackForce = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Health enemyHealth = collision.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);

                // Aplicar knockback usando ApplyKnockback
                SlimeController slimeController = collision.GetComponent<SlimeController>();
                if (slimeController != null)
                {
                    Vector2 knockbackDirection = CalculateKnockbackDirection(collision.transform);
                    slimeController.ApplyKnockback(knockbackDirection, knockbackForce);
                }
            }
        }
    }

    private Vector2 CalculateKnockbackDirection(Transform enemyTransform)
    {
        Vector2 attackPosition = transform.position;
        Vector2 enemyPosition = enemyTransform.position;
        Vector2 direction = (enemyPosition - attackPosition).normalized;
        return direction;
    }
}
