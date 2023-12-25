using UnityEditor;
using UnityEngine;

public class Ship1DLSystem : MonoBehaviour
{
    Transform ship;
    Rigidbody2D unitrb;
    float aliensDestroyed = 0;
    int armor;
    float speed;
    bool movementBool = true;
    public Vector2 endAreaMin;
    public Vector2 endAreaMax;

    // Start is called before the first frame update
    void Start()
    {
        armor = 2;
        speed = 1.5f;
        unitrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        MovementFunction();

        ship = transform;

        if (true)
        {
            float distance = Vector3.Distance(ship.transform.position, (endAreaMin + endAreaMax) * 0.5f);

            if (distance <= Mathf.Abs(endAreaMax.x - endAreaMin.x) * 0.5f && ship.transform.position.y <= 5f)
            {
                GM.ShipsAcross += 1;
                Destroy(gameObject, 0f);
                Debug.Log("/s Ship1 Landed on Enemy Planet!");
            }
        }
    }

    private void MovementFunction()
    {
        if (movementBool == true)
        {
            unitrb.velocity = new Vector2(-speed, speed);
        }
        else if (movementBool == false)
        {
            unitrb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject, 0f);
            Debug.Log("/s Ship1 Landed on Asteroid!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            Destroy(collision.gameObject, 0f);
            Debug.Log("/s Ship1 Destroyed Alien!");
            aliensDestroyed += 1;
        }
    }

    private void Die()
    {
        if (aliensDestroyed >= armor)
        {
            Destroy(gameObject, 0f);
            Debug.Log("/s Ship1 Destroyed by Battle!");
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
