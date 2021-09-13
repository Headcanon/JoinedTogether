using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSMovement_Classic : PlayerElement
{
    // Start is called before the first frame update
    void Start()
    {
        moveData.cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveData.isGrounded && moveData.velocity.y < 0)
        {
            moveData.velocity.y = -1.5f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move;
        if (moveData.localAxis)
        {
            move = transform.right * x + transform.forward * z;
        }
        else
        {
            move = Vector3.right * x + Vector3.forward * z;
        }

        moveData.cc.Move(move * moveData.speed * Time.deltaTime) ;

        if(Input.GetButtonDown("Jump") && moveData.isGrounded)
        {
            moveData.velocity.y = Mathf.Sqrt(moveData.jumpHeight * -2f * moveData.gravity);
        }

        moveData.velocity.y += moveData.gravity * Time.deltaTime;

        moveData.cc.Move(moveData.velocity * Time.deltaTime);
    }
}
