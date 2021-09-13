using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public float tileUpTime = .2f;
    public float tileFallTime = 1f;
    public TileLifter[] baseTiles;

    private NonRepeatableList<TileLifter> filteredTiles;

    [SerializeField]
    private List<TileLifter> activeTiles;

    private void Start()
    {
        filteredTiles = new NonRepeatableList<TileLifter>();
        //activeTiles = new List<GameObject>();

        foreach(TileLifter t in baseTiles)
        {
            filteredTiles.Add(t);
        }
    }

    public void SpawnTile(Vector3 pos)
    {
        TileLifter nextTile = filteredTiles.NoRepeatRnd();

        if (activeTiles[activeTiles.Count-1].transform.position != pos)
        {
            activeTiles.Add(Instantiate(nextTile, pos, nextTile.transform.rotation));

            if(activeTiles.Count >= 3)
            {
                activeTiles[0].EndTile(-20);
                activeTiles.RemoveAt(0);
            }
        }
    }
}
