using UnityEngine;

public class MABSystem : MonoBehaviour
{
    float alienCaps = 0;
    public GameObject enemyBase;

    // Update is called once per frame
    void Update()
    {
        if (alienCaps >= 20)
        {
            Instantiate(enemyBase, transform.position, Quaternion.identity);
            Destroy(gameObject, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Alien")
        {
            alienCaps += 1;
        }
    }
}
