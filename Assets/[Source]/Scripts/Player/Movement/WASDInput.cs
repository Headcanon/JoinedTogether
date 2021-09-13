using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDInput : MonoBehaviour, IInput
{
    [SerializeField] private int moveDistance = 1;
    [SerializeField] private float jumpForce = 6;

    public event Action<int> Move;
    public event Action<float> Jump;
    public event Action Fail;

    private Stretcher st;

    private void Awake()
    {
        st = transform.parent.GetComponentInChildren<Stretcher>();
        Fail += ()=> print("fail");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Jump(jumpForce);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            if (st.stretched < st.stretchMax)
            {
                st.stretched++;
                Move(-moveDistance);
            }
            else
            {
                Fail();
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (st.stretched > 0)
            {
                st.stretched--;
                Move(moveDistance);
            }
            else
            {
                Fail();
            }
        }
    }
}
