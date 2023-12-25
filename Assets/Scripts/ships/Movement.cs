using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D unitrb;
    bool movementBool = true;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        unitrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementFunction();
    }

    private void MovementFunction()
    {
        if (movementBool)
        {
            unitrb.velocity = new Vector2(unitrb.velocity.x, speed);
        }
        else if (movementBool == false)
        {
            unitrb.velocity = Vector2.zero;
        }
    }
}
