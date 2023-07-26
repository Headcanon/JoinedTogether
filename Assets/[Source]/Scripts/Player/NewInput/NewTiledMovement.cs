using UnityEngine;
using UnityEngine.InputSystem;

public class NewTiledMovement : MonoBehaviour
{
    public bool isGrounded;

    private Rigidbody rb;
    PlayerInput input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        input = GetComponent<PlayerInput>();
        input.actions["Move"].performed += MoveTile;
        input.actions["Jump"].performed += Jump;
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -5)
        {
            FindObjectOfType<SceneLoader>().Die();
        }
    }

    private void MoveTile(InputAction.CallbackContext context)
    {
        int xAxis = (int) context.ReadValue<float>();
        transform.position += new Vector3(xAxis, 0, 0);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.velocity += Vector3.up * context.ReadValue<float>();
        }
    }
}
