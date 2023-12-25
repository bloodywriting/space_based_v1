using UnityEngine;

public class AlienShipSystem : MonoBehaviour
{
    Transform ship;
    public Vector2 endAreaMin;
    public Vector2 endAreaMax;
    public GameObject unitPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // add to totalalienship  singletary
    }

    // Update is called once per frame
    void Update()
    {
        ship = transform;

        if (true)
        {
            float distance = Vector3.Distance(ship.transform.position, (endAreaMin + endAreaMax) * 0.5f);

            if (distance <= Mathf.Abs(endAreaMax.x - endAreaMin.x) * 0.5f)
            {
                GM.AlienInvaders += 1;
                Destroy(gameObject, 0f);
                Debug.Log("Alien #" + GM.AlienInvaders + " Invaded!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject, 0f);
            Debug.Log("Alien Ship Landed on Asteroid!");
        }
    }
}
