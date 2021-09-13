using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TileLifter : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject moveable;

    private TileManager tm;

    private void Start()
    {
        tm = FindObjectOfType<TileManager>();
        StartTile(0);
    }

    private bool doOnce = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doOnce = !doOnce;
            if (doOnce)
            {
                tm.SpawnTile(spawnPoint.position);
            }
        }
    }

    private void StartTile(float moveTo)
    {
        LeanTween.moveY(moveable, moveTo, tm.tileUpTime).setEaseInOutSine();
    }

    public void EndTile(float moveTo)
    {
        LeanTween.moveY(gameObject, moveTo, tm.tileFallTime).setOnComplete( ()=> Destroy(gameObject));
    }
}
