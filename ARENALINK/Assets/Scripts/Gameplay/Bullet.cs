using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }
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
