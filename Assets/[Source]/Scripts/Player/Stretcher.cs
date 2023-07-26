using UnityEngine;

public class Stretcher : MonoBehaviour
{
    [SerializeField] private Material lineMat;

    private LineRenderer linerenderer;

    public Transform letPlayer;
    public Transform rightPlayer;

    public int stretchMax = 2;
    public int stretchLevel;

    void Start() { linerenderer = transform.parent.GetComponent<LineRenderer>();}

    void Update()
    {   
        linerenderer.SetPosition(0, letPlayer.position);
        linerenderer.SetPosition(1, rightPlayer.position);

        switch (stretchLevel)
        {
            case 1: { lineMat.color = Color.grey; break; }
            case 2: { lineMat.color = Color.black; break; }
        }
    }
}
