using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledMovement : MonoBehaviour
{
    public bool isGrounded;

    private Rigidbody rb;
    private IInput input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        input = GetComponent<IInput>();
        input.Move += MoveTile;
        input.Jump += Jump;
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -5)
        {
            FindObjectOfType<SceneLoader>().Die();
        }
    }

    private void MoveTile(int tileSize)
    {
        transform.position += new Vector3(tileSize, 0, 0);        
    }

    private void Jump(float force)
    {
        if(isGrounded)
        {
            rb.velocity += Vector3.up * force;
        }
    }
}
