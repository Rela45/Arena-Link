
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnRandomObject : MonoBehaviour
{
    
    public GameObject[] debriPrefabs;
    
    private float _speed = 1f;
    
    void Start()
    {
        StartCoroutine(SpawnRandomRoutine());
    }

    System.Collections.IEnumerator SpawnRandomRoutine()
    {
        while (true)
        {
            SpawnRandom();
            yield return new WaitForSeconds(1f);
        }
    }
    
    void Update()
    {
        // if (parentTransform == null) return;
        //     parentTransform.position = new Vector3(
        //     parentTransform.position.x,
        //     parentTransform.position.y - _speed * Time.deltaTime,
        //     parentTransform.position.z
        // );
    }
    void SpawnRandom()
    {
        Vector2 randomSpawn = new Vector2(Random.Range(-10, 10), 4.9f );
        GameObject prefabToSpawn = debriPrefabs[Random.Range(0, debriPrefabs.Length)];
        GameObject go = Instantiate(prefabToSpawn, randomSpawn, Quaternion.identity);
        var rb = go.GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = Vector2.down * _speed;
        // Transform spawnedT = go.transform;
        // spawnedT.SetParent(parentTransform);
    }
}
