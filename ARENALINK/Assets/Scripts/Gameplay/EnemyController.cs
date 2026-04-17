using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Raycast Debug")]
    public float rayLength = 60f;
    public Color hitColor = Color.red;
    public Color missColor = Color.green;
    public LayerMask rayMask = 0;

    public Weapon weapon;
    
    [Header("Fire Rate")]
    public float fireRate = 0.5f;  // Fire every 0.5 seconds
    private float fireTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;  // Decrease timer each frame
        DrawRaycast(transform.position, Vector2.down, rayLength, hitColor, missColor, rayMask);
    }

    // Performs a Physics2D.Raycast and draws a debug line: red if hit, green if miss
    public void DrawRaycast(Vector2 origin, Vector2 direction, float length, Color hitColor, Color missColor, LayerMask mask)
    {
        // Normalize the direction
        Vector2 normalizedDirection = direction.normalized;
        
        // Perform 2D Raycast
        RaycastHit2D hit = Physics2D.Raycast(origin, normalizedDirection, rayLength, mask);
        
        if (hit.collider != null)
        {
            // Hit: draw from origin to contact point
            Debug.Log($"HIT: {hit.collider.gameObject.name} at distance {hit.distance}");
            Debug.DrawLine(origin, hit.point, hitColor);
            
            // Only fire if cooldown is ready
            if (fireTimer <= 0f)
            {
                weapon.Fire();
                fireTimer = fireRate;  // Reset cooldown
            }
        }
        else
        {
            // Miss: draw full ray length
            Debug.Log("MISS - no colliders hit by raycast");
            Debug.DrawLine(origin, origin + normalizedDirection * length, missColor);
        }
    }
}
