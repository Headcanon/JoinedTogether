using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField]
    private LayerMask layer;

    private TiledMovement player;

    private void Start()
    {
        player = transform.parent.GetComponent<TiledMovement>();
    }

    private bool isGrounded;
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, .2f, layer);
        player.isGrounded = isGrounded;
    }
}
