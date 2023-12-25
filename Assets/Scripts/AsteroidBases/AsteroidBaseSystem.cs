using UnityEngine;

public class AsteroidBaseSystem : MonoBehaviour
{
    float shipCaps = 0;
    float alienCaps = 0;
    public float shipCapsNeeded = 0;
    public float alienCapsNeeded = 0;
    public GameObject enemyBase;
    public GameObject allySuperBase;

    // Update is called once per frame
    void Update()
    {
        if (shipCaps >= shipCapsNeeded)
        {
            Instantiate(allySuperBase, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
            Debug.Log("Ally Super Base Created!");
        }
        if (alienCaps >= alienCapsNeeded)
        {
            Instantiate(enemyBase, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
            Debug.Log("Asteroid Base Captured by Enemy!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            shipCaps += 1;
            Debug.Log("Ship Landed on Asteroid Base!");
        }
        else if (collider.gameObject.tag == "Alien")
        {
            alienCaps += 1;
            Debug.Log("Alien Ship Landed on Asteroid Base!");
        }
    }
}
