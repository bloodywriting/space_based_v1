using System.Collections;
using UnityEngine;

public class DoubleShipSpawner : MonoBehaviour
{
    public GameObject unitPrefab;
    public float SpawnRate;
    public float VertDisplacement;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawner()
    {
        while (true)
        {
            Vector3 positionLeft = transform.position + new Vector3(-0.3f, VertDisplacement, 0);
            Vector3 positionRight = transform.position + new Vector3(0.3f, VertDisplacement, 0);
            Instantiate(unitPrefab, positionLeft, Quaternion.identity);
            Instantiate(unitPrefab, positionRight, Quaternion.identity);
            yield return new WaitForSeconds(SpawnRate);
        }
    }
}
