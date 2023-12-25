using System;
using System.Collections;
using UnityEngine;

public class SerpentineMovement : MonoBehaviour
{
     float amplitude;  // Adjust the amplitude for the serpentine motion
    float lifeTime;
    float frequency;
    int movementCase;
    float speed;

    private Rigidbody2D unitrb;
    private bool movementBool = true;

    // Start is called before the first frame update
    void Awake()
    {
        MovementSelection();
        unitrb = GetComponent<Rigidbody2D>();
        StartCoroutine(ShipLifeTimer());
    }

    // Update is called once per frame
    void Update()
    {
        // Incremental input based on time
        float input = lifeTime;

        // Calculate xVelocity using the sine function with amplitude
        float xVelocity = amplitude * Mathf.Sin(input);

        MovementFunction(xVelocity);
    }

    private void MovementFunction(float xVel)
    {
        if (movementBool)
        {
            // Create a new Vector2 with x and y velocities
            Vector2 newVelocity = new Vector2(xVel, speed);

            // Apply the new velocity to the Rigidbody2D
            unitrb.velocity = newVelocity;
        }
        else
        {
            unitrb.velocity = Vector2.zero;
        }
    }

    IEnumerator ShipLifeTimer()
    {
        while (true)
        {
            lifeTime += frequency;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void MovementSelection()
    {
        System.Random random = new System.Random();

        // Generate a random integer within a given range
        movementCase = random.Next(1, 3);

        switch (movementCase)
        {
            case 1:
                Console.WriteLine("movementCase 1");
                amplitude = 0.7f;
                frequency = 0.6f;
                speed = 2.2f;
                break;
            case 2:
                Console.WriteLine("movementCase 2");
                amplitude = 0.9f;
                frequency = 0.5f;
                speed = 2.1f;
                break;
            case 3:
                Console.WriteLine("movementCase 3");
                amplitude = 0.5f;
                frequency = 0.7f;
                speed = 2.3f;
                break;
        }
    }
     
}