using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dieable : MonoBehaviour
{
    private SoundMaster sm;
    private void Start()
    {
        sm = FindObjectOfType<SoundMaster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            FindObjectOfType<SceneLoader>().Die();
        }
    }
}
