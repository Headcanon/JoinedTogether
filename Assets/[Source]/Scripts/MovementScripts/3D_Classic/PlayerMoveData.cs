using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveData : MonoBehaviour
{
    [Header("Controller")]
    public bool localAxis = true;
    public CharacterController cc;
    public float mouseSensitivity = 100f;
    public float speed = 25f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Vector3 velocity;


    [Header("GroundCheck")]
    public LayerMask groundMask;
    public float groundDistance = .4f;
    public bool isGrounded = false;
}

public class PlayerElement : MonoBehaviour
{
    protected PlayerMoveData moveData
    {
        get { return FindObjectOfType<PlayerMoveData>(); }
    }
}
