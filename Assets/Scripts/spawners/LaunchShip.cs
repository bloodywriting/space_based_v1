using UnityEditor;
using UnityEngine;

public class LaunchShip : MonoBehaviour
{
    public GameObject Ship1Prefab;
    public GameObject Ship2Prefab;
    public GameObject Ship3Prefab;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    public float ship1SpawnCooldown;
    public float ship2SpawnCooldown;
    public float ship3SpawnCooldown;

    private void Start()
    {
        GM.Ship1SpawnCooldown = ship1SpawnCooldown;
        GM.Ship2SpawnCooldown = ship2SpawnCooldown;
        GM.Ship3SpawnCooldown = ship3SpawnCooldown;
    }

    void Update()
    {
        // Spawning code for Ship 1 prefab
        // If no ships spawned, ability to instantly spawn
        if (GM.Ship1Spawned == 0)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                Debug.Log("LaunchShipUpdate 0");

                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                // Calculate the distance from the mouse position to the center of the semicircle
                float distance = Vector3.Distance(mousePosition, (spawnAreaMin + spawnAreaMax) * 0.5f);

                // Check if the distance is less than the radius of the semicircle
                if (distance <= Mathf.Abs(spawnAreaMax.x - spawnAreaMin.x) * 0.5f)
                {
                    // Get the height of the unit's sprite
                    SpriteRenderer unitSpriteRenderer = Ship1Prefab.GetComponent<SpriteRenderer>();
                    float unitHeight = unitSpriteRenderer.bounds.extents.y;

                    // Adjust the spawn position so that the bottom of the unit aligns with the click position
                    Vector3 spawnPosition = mousePosition + new Vector3(0, unitHeight, 0);

                    Instantiate(Ship1Prefab, spawnPosition, Quaternion.identity);
                    GM.Ship1Spawned += 1;
                    Debug.Log($"Ship1 #{GM.Ship1Spawned} Launched!");
                    GM.LastShip1SpawnTime = Time.time;
                }
            }
            else if (Input.GetKey(KeyCode.Q) && (Time.time - GM.LastShip1SpawnTime < ship1SpawnCooldown))
            {
                Debug.Log("Ship 1 Launch failed, cooldown not reached!");
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                Debug.Log("Ship 1 Launch failed for unknown reason!");
            }
        }
        // Regular spawn code, including cooldown conditions for timing
        else if(GM.Ship1Spawned > 0)
        {
            if (Input.GetKey(KeyCode.Q) && (Time.time - GM.LastShip1SpawnTime >= ship1SpawnCooldown))
            {
                Debug.Log("LaunchShipUpdate 0");

                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                // Calculate the distance from the mouse position to the center of the semicircle
                float distance = Vector3.Distance(mousePosition, (spawnAreaMin + spawnAreaMax) * 0.5f);

                // Check if the distance is less than the radius of the semicircle
                if (distance <= Mathf.Abs(spawnAreaMax.x - spawnAreaMin.x) * 0.5f)
                {
                    // Get the height of the unit's sprite
                    SpriteRenderer unitSpriteRenderer = Ship1Prefab.GetComponent<SpriteRenderer>();
                    float unitHeight = unitSpriteRenderer.bounds.extents.y;

                    // Adjust the spawn position so that the bottom of the unit aligns with the click position
                    Vector3 spawnPosition = mousePosition + new Vector3(0, unitHeight, 0);

                    Instantiate(Ship1Prefab, spawnPosition, Quaternion.identity);
                    GM.Ship1Spawned += 1;
                    Debug.Log($"Ship1 #{GM.Ship1Spawned} Launched!");
                    GM.LastShip1SpawnTime = Time.time;
                }
            }
            else if (Input.GetKey(KeyCode.Q) && (Time.time - GM.LastShip1SpawnTime < ship1SpawnCooldown))
            {
                Debug.Log("Ship 1 Launch failed, cooldown not reached!");
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                Debug.Log("Ship 1 Launch failed for unknown reason!");
            }
        }

        // Spawning code for ship 2 prefab
        // If no ships spawned, ability to instantly spawn
        if (GM.Ship2Spawned == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("LaunchShipUpdate 0");
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                // Calculate the distance from the mouse position to the center of the semicircle
                float distance = Vector3.Distance(mousePosition, (spawnAreaMin + spawnAreaMax) * 0.5f);

                // Check if the distance is less than the radius of the semicircle
                if (distance <= Mathf.Abs(spawnAreaMax.x - spawnAreaMin.x) * 0.5f)
                {
                    // Get the height of the unit's sprite
                    SpriteRenderer unitSpriteRenderer = Ship2Prefab.GetComponent<SpriteRenderer>();
                    float unitHeight = unitSpriteRenderer.bounds.extents.y;

                    // Adjust the spawn position so that the bottom of the unit aligns with the click position
                    Vector3 spawnPosition = mousePosition + new Vector3(0, unitHeight, 0);

                    Instantiate(Ship2Prefab, spawnPosition, Quaternion.identity);
                    GM.Ship2Spawned += 1;
                    Debug.Log($"Ship2 #{GM.Ship2Spawned} Launched!");
                    GM.LastShip2SpawnTime = Time.time;
                }
            }
            else if (Input.GetKey(KeyCode.W) && (Time.time - GM.LastShip2SpawnTime < ship2SpawnCooldown))
            {
                Debug.Log("Ship 2 Launch failed, cooldown not reached!");
            }
            else if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("Ship 2 Launch failed for unknown reason!");
            }
        }
        // Regular spawn code, including cooldown conditions for timing
        else if (GM.Ship2Spawned > 0)
        {
            if (Input.GetKey(KeyCode.W) && (Time.time - GM.LastShip2SpawnTime >= ship2SpawnCooldown))
            {
                Debug.Log("LaunchShipUpdate 0");
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                // Calculate the distance from the mouse position to the center of the semicircle
                float distance = Vector3.Distance(mousePosition, (spawnAreaMin + spawnAreaMax) * 0.5f);

                // Check if the distance is less than the radius of the semicircle
                if (distance <= Mathf.Abs(spawnAreaMax.x - spawnAreaMin.x) * 0.5f)
                {
                    // Get the height of the unit's sprite
                    SpriteRenderer unitSpriteRenderer = Ship2Prefab.GetComponent<SpriteRenderer>();
                    float unitHeight = unitSpriteRenderer.bounds.extents.y;

                    // Adjust the spawn position so that the bottom of the unit aligns with the click position
                    Vector3 spawnPosition = mousePosition + new Vector3(0, unitHeight, 0);

                    Instantiate(Ship2Prefab, spawnPosition, Quaternion.identity);
                    GM.Ship2Spawned += 1;
                    Debug.Log($"Ship2 #{GM.Ship2Spawned} Launched!");
                    GM.LastShip2SpawnTime = Time.time;
                }
            }
            else if (Input.GetKey(KeyCode.W) && (Time.time - GM.LastShip2SpawnTime < ship2SpawnCooldown))
            {
                Debug.Log("Ship 2 Launch failed, cooldown not reached!");
            }
            else if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("Ship 2 Launch failed for unknown reason!");
            }
        }

        // Spawning code for ship 3 prefab
        // If no ships spawned, ability to instantly spawn
        if (GM.Ship3Spawned == 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("LaunchShipUpdate 0");
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                // Calculate the distance from the mouse position to the center of the semicircle
                float distance = Vector3.Distance(mousePosition, (spawnAreaMin + spawnAreaMax) * 0.5f);

                // Check if the distance is less than the radius of the semicircle
                if (distance <= Mathf.Abs(spawnAreaMax.x - spawnAreaMin.x) * 0.5f)
                {
                    // Get the height of the unit's sprite
                    SpriteRenderer unitSpriteRenderer = Ship3Prefab.GetComponent<SpriteRenderer>();
                    float unitHeight = unitSpriteRenderer.bounds.extents.y;

                    // Adjust the spawn position so that the bottom of the unit aligns with the click position
                    Vector3 spawnPosition = mousePosition + new Vector3(0, unitHeight, 0);

                    Instantiate(Ship3Prefab, spawnPosition, Quaternion.identity);
                    GM.Ship3Spawned += 1;
                    Debug.Log($"Ship3 #{GM.Ship3Spawned} Launched!");
                    GM.LastShip3SpawnTime = Time.time;
                }
            }
            else if (Input.GetKey(KeyCode.E) && (Time.time - GM.LastShip3SpawnTime < ship3SpawnCooldown))
            {
                Debug.Log("Ship Launch failed, cooldown not reached!");
            }
        }
        // Regular spawn code, including cooldown conditions for timing
        else if (GM.Ship3Spawned > 0)
        {
            if (Input.GetKey(KeyCode.E) && (Time.time - GM.LastShip3SpawnTime >= ship3SpawnCooldown))
            {
                Debug.Log("LaunchShipUpdate 0");
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                // Calculate the distance from the mouse position to the center of the semicircle
                float distance = Vector3.Distance(mousePosition, (spawnAreaMin + spawnAreaMax) * 0.5f);

                // Check if the distance is less than the radius of the semicircle
                if (distance <= Mathf.Abs(spawnAreaMax.x - spawnAreaMin.x) * 0.5f)
                {
                    // Get the height of the unit's sprite
                    SpriteRenderer unitSpriteRenderer = Ship3Prefab.GetComponent<SpriteRenderer>();
                    float unitHeight = unitSpriteRenderer.bounds.extents.y;

                    // Adjust the spawn position so that the bottom of the unit aligns with the click position
                    Vector3 spawnPosition = mousePosition + new Vector3(0, unitHeight, 0);

                    Instantiate(Ship3Prefab, spawnPosition, Quaternion.identity);
                    GM.Ship3Spawned += 1;
                    Debug.Log($"Ship3 #{GM.Ship3Spawned} Launched!");
                    GM.LastShip3SpawnTime = Time.time;
                }
            }
            else if (Input.GetKey(KeyCode.E) && (Time.time - GM.LastShip3SpawnTime < ship3SpawnCooldown))
            {
                Debug.Log("Ship Launch failed, cooldown not reached!");
            }
        }
    }
    void OnDrawGizmos()
    {
        Handles.color = Color.green;

        // Calculate center and radius based on spawnAreaMin and spawnAreaMax
        Vector3 center = (spawnAreaMin + spawnAreaMax) * 0.5f;
        float radius = Mathf.Abs(spawnAreaMax.x - spawnAreaMin.x) * 0.5f;

        // Draw a semicircle opening downwards
        Vector3 from = center + Quaternion.Euler(0, 0, 0) * Vector3.right * radius;

        Handles.DrawWireArc(center, Vector3.forward, from - center, 180, radius);
    }
}