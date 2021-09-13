using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    [SerializeField]
    private float easySpeed;
    [SerializeField]
    private float mediumSpeed;
    [SerializeField]
    private float hardSpeed;
    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private Rigidbody rb1;
    [SerializeField]
    private Rigidbody rb2;

    private PointManager pm;
    private float currentSpeed;

    private void Awake()
    {
        pm = GetComponent<PointManager>();
        pm.levelChange += UpdateSpeed;
    }

    private void FixedUpdate()
    {
        if (pm.playing)
        {
            rb1.velocity = new Vector3(0, rb1.velocity.y, currentSpeed);
            rb2.velocity = new Vector3(0, rb2.velocity.y, currentSpeed);
        }
        else
        {
            rb1.velocity = new Vector3(0, rb1.velocity.y, 0);
            rb2.velocity = new Vector3(0, rb2.velocity.y, 0);
        }
    }

    private void UpdateSpeed(Level level)
    {
        switch (level)
        {
            case Level.Easy:
                {
                    currentSpeed = easySpeed;
                    break;
                }
            case Level.Medium:
                {
                    currentSpeed = mediumSpeed;
                    break;
                }
            case Level.Hard:
                {
                    currentSpeed = hardSpeed;
                    break;
                }
            case Level.MAX:
                {
                    currentSpeed = maxSpeed;
                    break;
                }
        }

    }
}
