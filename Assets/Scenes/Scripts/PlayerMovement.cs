using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 2000f; // Example default values
    public float sideForce = 500f;

    private float horizontalInput;

    private void Awake()
    {
        // Automatically assign the Rigidbody component if not already assigned
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        // Check if Rigidbody is still not assigned (in case it's missing from the GameObject)
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the GameObject!");
        }
    }
    

    private void Update()
    {
        // Get horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // Debug horizontal input
        Debug.Log("Horizontal Input: " + horizontalInput);

        // Check if player has fallen
        if (rb.position.y < -1f)
        {
            Debug.Log("Player fell off");
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void FixedUpdate()
    {
        if (rb == null) return; // Ensure rb is assigned

        // Apply forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // Apply side force based on input
        rb.AddForce(horizontalInput * sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}
