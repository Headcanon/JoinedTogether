using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stretcher : MonoBehaviour
{
    [SerializeField]
    private Material lineMat;

    private LineRenderer lr;

    public Transform p0;
    public Transform p1;

    public int stretchMax = 2;
    public int stretched;

    // Start is called before the first frame update
    void Start()
    {
        lr = transform.parent.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {   
        lr.SetPosition(0, p0.position);
        lr.SetPosition(1, p1.position);

        switch (stretched)
        {
            case 1:
                {
                    lineMat.color = Color.grey;
                    break;
                }
            case 2:
                {
                    lineMat.color = Color.black;
                    break;
                }
        }
    }
}
