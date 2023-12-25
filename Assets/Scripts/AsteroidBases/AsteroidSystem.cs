using UnityEngine;

public class AsteroidSystem : MonoBehaviour
{
    float shipCaps = 0;
    float alienCaps = 0;
    public GameObject AsteroidBase;
    public GameObject AlienAsteroidBase;

    // Update is called once per frame
    void Update()
    {
        if (shipCaps >= 5)
        {
            Instantiate(AsteroidBase, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
        }

        if (alienCaps >= 5)
        {
            Instantiate(AlienAsteroidBase, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            shipCaps += 1;
        }

        if (collider.gameObject.tag == "Alien")
        {
            alienCaps += 1;
        }
    }
}
