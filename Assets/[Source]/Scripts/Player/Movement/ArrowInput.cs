using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowInput : MonoBehaviour, IInput
{
    [SerializeField] private int moveDistance = 10;
    [SerializeField] private float jumpForce = 10;

    public event Action<int> Move;
    public event Action<float> Jump;
    public event Action Fail;

    public bool liberado = true;

    private Stretcher st;

    private void Awake()
    {
        st = transform.parent.GetComponentInChildren<Stretcher>();
        Fail += () => print("fail");
    }

    // Update is called once per frame
    void Update()
    {
        if (!liberado)
            return;

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump(jumpForce);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (st.stretched > 0)
            {
                st.stretched--;
                Move(-moveDistance);
            }
            else
            {
                Fail();
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (st.stretched < st.stretchMax)
            {
                st.stretched++;
                Move(moveDistance);
            }
            else
            {
                Fail();
            }
        }
    }
}
