using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    
    public GameObject[] debriPrefabs;
    void Update()
    {
        Vector2 randomSpawn = new Vector2(Random.Range(-110, 11), Random.Range(-11, 10));
    }
}
