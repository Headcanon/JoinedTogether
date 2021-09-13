using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TutorialState { AD, LeftRight, W, Up, DONE}
public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ad;
    [SerializeField]
    private GameObject leftRight;
    [SerializeField]
    private GameObject w;
    [SerializeField]
    private GameObject up;
    [SerializeField]
    private GameObject pontos;

    public TutorialState ts;
    private bool tarefa1, tarefa2;

    // Update is called once per frame
    void Update()
    {
        switch(ts)
        {
            case TutorialState.AD:
                {
                    if(Input.GetKeyDown(KeyCode.A))
                    {
                        tarefa1 = true;
                    }
                    if(tarefa1 && Input.GetKeyDown(KeyCode.D))
                    {
                        tarefa2 = true;
                    }

                    if(tarefa1 && tarefa2)
                    {
                        tarefa1 = false;
                        tarefa2 = false;

                        ad.SetActive(false);
                        leftRight.SetActive(true);

                        FindObjectOfType<ArrowInput>().liberado = true;

                        ts = TutorialState.LeftRight;
                    }
                    break;
                }
            case TutorialState.LeftRight:
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        tarefa1 = true;
                    }
                    if (tarefa1 && Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        tarefa2 = true;
                    }

                    if (tarefa1 && tarefa2)
                    {
                        tarefa1 = false;
                        tarefa2 = false;

                        leftRight.SetActive(false);
                        w.SetActive(true);

                        ts = TutorialState.W;
                    }
                    break;
                }
            case TutorialState.W:
                {
                    if(Input.GetKeyDown(KeyCode.W))
                    {
                        tarefa1 = true;
                    }

                    if (tarefa1)
                    {
                        tarefa1 = false;
                                                
                        w.SetActive(false);
                        up.SetActive(true);

                        ts = TutorialState.Up;
                    }                    
                    break;
                }
            case TutorialState.Up:
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        tarefa1 = true;
                    }

                    if (tarefa1)
                    {
                        tarefa1 = false;

                        up.SetActive(false);
                        pontos.SetActive(true);

                        FindObjectOfType<PointManager>().playing = true;
                        ts = TutorialState.DONE;
                    }
                    break;
                }
        }
    }
}
