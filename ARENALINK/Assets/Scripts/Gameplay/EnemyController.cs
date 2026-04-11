using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Raycast Debug")]
    public float rayLength = 25f;
    public Color hitColor = Color.red;
    public Color missColor = Color.green;
    public LayerMask rayMask = ~0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        DrawRaycast(transform.position, Vector3.down, rayLength, hitColor, missColor, rayMask);
    }

    // Performs a Physics.Raycast and draws a debug line: red if hit, green if miss
    public void DrawRaycast(Vector3 origin, Vector3 direction, float length, Color hitColor, Color missColor, LayerMask mask)
    {
        Ray ray = new Ray(origin, direction.normalized);
        RaycastHit hit;
        
        // Try to raycast, excluding this object's own collider
        Collider thisCollider = GetComponent<Collider>();
        
        // Use OverlapSphere first to see what's in range
        Collider[] colliders = Physics.OverlapSphere(origin + direction.normalized * (length / 2f), length / 2f, mask);
        Debug.Log($"Colliders in range: {colliders.Length}");
        foreach (var col in colliders) //this is not working 
        {
            Debug.Log($"  - {col.gameObject.name} (layer: {LayerMask.LayerToName(col.gameObject.layer)})");//this is not working 
        }
        
        if (Physics.Raycast(ray, out hit, length, mask) && (thisCollider == null || hit.collider != thisCollider))//this is not working 
        {
            // Hit: draw from origin to contact point
            Debug.Log($"HIT: {hit.collider.gameObject.name} at distance {hit.distance}");
            Debug.DrawRay(origin, (hit.point - origin), hitColor);
        }
        else
        {
            // Miss: draw full ray length
            Debug.Log("MISS - no colliders hit by raycast");
            Debug.DrawRay(origin, direction.normalized * length, missColor);
        }
    }
}
