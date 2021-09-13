using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElement : MonoBehaviour
{
    [SerializeField]
    private Vector3 finalSize = Vector3.one;
    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, finalSize, .5f).setDelay(.3f).setEaseSpring();
    }
}
