using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTweens : MonoBehaviour
{
    [SerializeField] private float tweenTime = .3f;
    [SerializeField] private float tweenIntensity = 30f;

    private IInput input;
    private void Awake()
    {
        input = GetComponent<IInput>();
        input.Fail += () => LeanTween.rotateX(gameObject, tweenIntensity, tweenTime).setEasePunch();
    }
}
