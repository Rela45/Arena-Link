using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] private string ignoreTag = "UpperLimit";
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(ignoreTag))return;
        Destroy(gameObject);
    }
}
