using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour
{
    [SerializeField]
    private AudioSource max;
    [SerializeField]
    private AudioSource jump;
    [SerializeField]
    private AudioSource damage;
    [SerializeField]
    private AudioSource walk;
    [SerializeField]
    private AudioSource ui;
    
    public void PlayMax()
    {
        max.Play();
    }

    public void PlayJump()
    {
        jump.Play();
    }

    public void PlayDamage()
    {
        damage.Play();
    }

    public void PlayWalk()
    {
        walk.Play();
    }

    public void PlayUI()
    {
        ui.Play();
    }
}
