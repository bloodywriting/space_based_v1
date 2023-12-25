using System.Collections;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameObject unitPrefab;
    public float SpawnRate = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            Vector3 position = transform.position + new Vector3(0, -0.7f, 0);
            Instantiate(unitPrefab, position, Quaternion.identity);
            yield return new WaitForSeconds(SpawnRate);
            Debug.Log("Alien Spawned!");
        }
    }
}
