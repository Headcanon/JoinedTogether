using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSounds : MonoBehaviour
{
    private IInput input;
    private SoundMaster sm;
    private void Awake()
    {
        sm = FindObjectOfType<SoundMaster>();

        input = GetComponent<IInput>();
        input.Move += (int i)=> sm.PlayWalk();
        input.Jump += (float f) => sm.PlayJump();
        input.Fail += () => sm.PlayMax();
    }
}
