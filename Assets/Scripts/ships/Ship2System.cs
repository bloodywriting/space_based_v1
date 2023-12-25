using UnityEngine;
using UnityEditor;

public class Ship2System : MonoBehaviour
{
    Transform ship;
    public Vector2 endAreaMin;
    public Vector2 endAreaMax;
    int aliensDestroyed = 0;
    int S2Armor = 4;

    // Update is called once per frame
    void Update()
    {
        ship = transform;

        if (true)
        {
            float distance = Vector3.Distance(ship.transform.position, (endAreaMin + endAreaMax) * 0.5f);

            if (distance <= Mathf.Abs(endAreaMax.x - endAreaMin.x) * 0.5f && ship.transform.position.y <= 5f)
            {
                GM.ShipsAcross += 1;
                Destroy(gameObject, 0f);
                Debug.Log("/s Ship2 Landed on Enemy Planet!");
            }
        }

        Die();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject, 0f);
            Debug.Log("/s Ship2 Landed on Asteroid!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            Destroy(collision.gameObject, 0f);
            Debug.Log("/s Ship2 Destroyed Alien!");
            aliensDestroyed += 1;
        }
    }

    private void Die()
    {
        if (aliensDestroyed >= S2Armor)
        {
            Destroy(gameObject, 0f);
            Debug.Log("/s Ship2 Destroyed by Battle!");
        }
    }

    void OnDrawGizmos()
    {
        Handles.color = Color.magenta;

        // Calculate center and radius based on spawnAreaMin and spawnAreaMax
        Vector3 center = (endAreaMin + endAreaMax) * 0.5f;
        float radius = Mathf.Abs(endAreaMax.x - endAreaMin.x) * 0.5f;

        // Draw a semicircle opening downwards
        Vector3 from = center + Quaternion.Euler(0, 0, 180) * Vector3.right * radius;

        Handles.DrawWireArc(center, Vector3.forward, from - center, 180, radius);
    }
}
