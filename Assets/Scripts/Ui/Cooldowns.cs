using UnityEngine;
using UnityEngine.UI;

public class Cooldowns : MonoBehaviour
{

    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    float distance;

    [Header("Ship 1")]
    public Image ship1Image;
    bool isCooldown1 = false;
    public KeyCode ship1;

    [Header("Ship 2")]
    public Image ship2Image;
    bool isCooldown2 = false;
    public KeyCode ship2;

    [Header("Ship 3")]
    public Image ship3Image;
    bool isCooldown3 = false;
    public KeyCode ship3;



    // Start is called before the first frame update
    void Start()
    {
        ship1Image.fillAmount = 0;
        ship2Image.fillAmount = 0;
        ship3Image.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ship1();
        Ship2();
        Ship3();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // Calculate the distance from the mouse position to the center of the semicircle
        distance = Vector3.Distance(mousePosition, (spawnAreaMin + spawnAreaMax) * 0.5f);
    }

    // Cooldown display for ship 1
    void Ship1()
    {
        // Start of game condition when no ships have been spawned
        if (GM.Ship1Spawned == 0)
        {
            // If key is pressed at correct distance, isCooldown1 set to true and display is filled
            if (Input.GetKey(ship1) && distance <= Mathf.Abs(spawnAreaMax.x - spawnAreaMin.x) * 0.5f)
            {
                isCooldown1 = true;
                ship1Image.fillAmount = 1;
            }

            // Cooldown1 display will steadily reduce fill until empty
            if (isCooldown1)
            {
                ship1Image.fillAmount -= 1 / GM.Ship1SpawnCooldown * Time.deltaTime;

                if (ship1Image.fillAmount <= 0)
                {
                    ship1Image.fillAmount = 0;
                    isCooldown1 = false;
                }
            }
        }
        else if (GM.Ship1Spawned > 0)
        {
            // If key is pressed at correct distance and isCooldown1 is false,set cooldown1 display true
            if (Input.GetKey(ship1) && isCooldown1 == false && Time.time >= GM.Ship1SpawnCooldown && distance <= Mathf.Abs(spawnAreaMax.x - spawnAreaMin.x) * 0.5f)
            {
                isCooldown1 = true;
                ship1Image.fillAmount = 1;
            }

            // Cooldown1 display will steadily reduce fill until empty
            if (isCooldown1)
            {
                ship1Image.fillAmount -= 1 / GM.Ship1SpawnCooldown * Time.deltaTime;

                if (ship1Image.fillAmount <= 0)
                {
                    ship1Image.fillAmount = 0;
                    isCooldown1 = false;
                }
            }
        }
    }

    void Ship2()
    {
        // Start of game condition when no ships have been spawned
        if (GM.Ship2Spawned == 0)
        {
            // If key is pressed at correct distance,set isCooldown2 true and fill display
            if (Input.GetKey(ship2) && distance <= Mathf.Abs(spawnAreaMax.x - spawnAreaMin.x) * 0.5f)
            {
                isCooldown2 = true;
                ship2Image.fillAmount = 1;
            }

            // Cooldown2 display will steadily reduce fill until empty
            if (isCooldown2)
            {
                ship2Image.fillAmount -= 1 / GM.Ship2SpawnCooldown * Time.deltaTime;

                if (ship2Image.fillAmount <= 0)
                {
                    ship2Image.fillAmount = 0;
                    isCooldown2 = false;
                }
            }
        }
        else if (GM.Ship2Spawned > 0)
        {
            // If key is pressed at correct distance and isCooldown2 is false, set isCooldown2 true and fill display
            if (Input.GetKey(ship2) && isCooldown2 == false && Time.time >= GM.Ship2SpawnCooldown && distance <= Mathf.Abs(spawnAreaMax.x - spawnAreaMin.x) * 0.5f)
            {
                isCooldown2 = true;
                ship2Image.fillAmount = 1;
            }

            // Cooldown2 display will steadily reduce fill until empty
            if (isCooldown2)
            {
                ship2Image.fillAmount -= 1 / GM.Ship2SpawnCooldown * Time.deltaTime;

                if (ship2Image.fillAmount <= 0)
                {
                    ship2Image.fillAmount = 0;
                    isCooldown2 = false;
                }
            }
        }
    }

    void Ship3()
    {
        // Start of game condition when no ships have been spawned
        if (GM.Ship3Spawned == 0)
        {
            // If key is pressed at correct distance,set isCooldown3 true and fill display
            if (Input.GetKey(ship3) && distance <= Mathf.Abs(spawnAreaMax.x - spawnAreaMin.x) * 0.5f)
            {
                isCooldown3 = true;
                ship3Image.fillAmount = 1;
            }

            // Cooldown3 display will steadily reduce fill until empty
            if (isCooldown3)
            {
                ship3Image.fillAmount -= 1 / GM.Ship3SpawnCooldown * Time.deltaTime;

                if (ship3Image.fillAmount <= 0)
                {
                    ship3Image.fillAmount = 0;
                    isCooldown3 = false;
                }
            }
        }
        if (GM.Ship3Spawned > 0)
        {
            // If key is pressed at correct distance and isCooldown3 is false, set isCooldown3 true and fill display
            if (Input.GetKey(ship3) && isCooldown3 == false && Time.time >= GM.Ship3SpawnCooldown && distance <= Mathf.Abs(spawnAreaMax.x - spawnAreaMin.x) * 0.5f)
            {
                isCooldown3 = true;
                ship3Image.fillAmount = 1;
            }

            // Cooldown3 display will steadily reduce fill until empty
            if (isCooldown3)
            {
                ship3Image.fillAmount -= 1 / GM.Ship3SpawnCooldown * Time.deltaTime;

                if (ship3Image.fillAmount <= 0)
                {
                    ship3Image.fillAmount = 0;
                    isCooldown3 = false;
                }
            }
        } 
    }
}
