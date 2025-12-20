using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletDamage = 2;
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        if (other.collider.TryGetComponent<Health>(out var health))
        health.Damage(bulletDamage);
        else
        Debug.LogWarning("Enemy has no Health: " + other.gameObject.name);
        
    }
}
