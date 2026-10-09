using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    // Requirement: Add a counter for collected objects
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0; // Initialize the count to zero at start
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        // Requirement: Apply forces to the ball to MOVE
        rb.AddForce(movement * speed);
    }

    // Requirement: Detect contact events to collect and pick-up game objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false); // Pick up the object by hiding it
            count = count + 1;                 // Count the collected object
            Debug.Log("Score: " + count);      // Print the count to the Unity Console
        }
    }
}
