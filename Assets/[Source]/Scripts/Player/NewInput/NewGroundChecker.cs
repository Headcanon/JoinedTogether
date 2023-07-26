using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGroundChecker : MonoBehaviour
{
    [SerializeField]
    private LayerMask layer;

    private NewTiledMovement player;

    private void Start()
    {
        player = transform.parent.GetComponent<NewTiledMovement>();
    }

    private bool isGrounded;
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, .2f, layer);
        player.isGrounded = isGrounded;
    }
}
