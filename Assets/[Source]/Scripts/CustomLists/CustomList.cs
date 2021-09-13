using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomList <T> : MonoBehaviour
{
    protected List<T> customlList;

    public CustomList()
    {
        customlList = new List<T>();
    }

    public bool Add(T obj)
    {
        if (obj == null)
            return false;

        customlList.Add(obj);
        return true;
    }

    public T Rnd()
    {
        return customlList[Random.Range(0, customlList.Count)];
    }
}
