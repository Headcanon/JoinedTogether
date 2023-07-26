using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMovement : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 5f;

    public int distance = 1;
    public bool WASD;
    public bool isGrounded = false;

    private Stretcher st;
    private Rigidbody rb;

    private TutorialManager tm;
    private SoundMaster sm;

    private void Start()
    {
        st = transform.parent.GetComponentInChildren<Stretcher>();
        rb = GetComponent<Rigidbody>();

        tm = FindObjectOfType<TutorialManager>();
        sm = FindObjectOfType<SoundMaster>();
    }

    void Update()
    {
        if (WASD)
        {
            if (Input.GetKeyDown(KeyCode.A) && st.stretchLevel < st.stretchMax)
            {
                st.stretchLevel++;
                transform.position += new Vector3(-distance, 0, 0);
                sm.PlayWalk();
            }
            else if (Input.GetKeyDown(KeyCode.D) && st.stretchLevel > 0)
            {
                st.stretchLevel--;
                transform.position += new Vector3(distance, 0, 0);
                sm.PlayWalk();
            }
            else if (Input.GetKeyDown(KeyCode.A) && st.stretchLevel >= st.stretchMax)
            {
                CantWalk();
            }
            else if (Input.GetKeyDown(KeyCode.D) && st.stretchLevel <= 0)
            {
                CantWalk();
            }

            if (isGrounded && Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity += Vector3.up * jumpForce;
                sm.PlayJump();
            }
        }
        else if(!WASD && tm.ts != TutorialState.AD)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && st.stretchLevel > 0)
            {
                st.stretchLevel--;
                transform.position += new Vector3(-distance, 0, 0);
                sm.PlayWalk();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && st.stretchLevel < st.stretchMax)
            {
                st.stretchLevel++;
                transform.position += new Vector3(distance, 0, 0);
                sm.PlayWalk();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && st.stretchLevel >= st.stretchMax)
            {
                CantWalk();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && st.stretchLevel <= 0)
            {
                CantWalk();
            }

            if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity += Vector3.up * jumpForce;
                sm.PlayJump();
            }
        }

        if(transform.position.y < -5)
        {
            FindObjectOfType<SceneLoader>().Die();
        }
    }

    private void CantWalk()
    {
        sm.PlayMax();
        LeanTween.rotate(gameObject, new Vector3(30, 0), .3f).setEasePunch();
    }
}
