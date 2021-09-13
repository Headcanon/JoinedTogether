using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Level { Easy, Medium, Hard, MAX }
public class PointManager : MonoBehaviour
{
    [SerializeField]
    private int medium;
    [SerializeField]
    private int hard;
    [SerializeField]
    private int max;

    [SerializeField]
    private TextMeshProUGUI ugui;

    public bool playing = true;
    public int pontos = 0;
    public event Action<Level> levelChange;

    private Level level = Level.Easy;

    private void Start()
    {
        levelChange += (Level lvl) => level = lvl;
        levelChange(Level.Easy);
    }

    private float timer = 1;
    private void Update()
    {
        ugui.text = pontos.ToString();

        timer -= Time.deltaTime;
        if(timer <=0 && playing)
        {
            pontos++;
            timer = 1;
        }

        switch(level)
        {
            case Level.Easy:
                {
                    if(pontos > medium)
                    {
                        levelChange(Level.Medium);
                    }
                    break;
                }
            case Level.Medium:
                {
                    if (pontos > hard)
                    {
                        levelChange(Level.Hard);
                    }
                    break;
                }
            case Level.Hard:
                {
                    if (pontos > max)
                    {
                        levelChange(Level.MAX);
                    }
                    break;
                }
        }
    } 
}
