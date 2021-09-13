using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonRepeatableList <T>: CustomList <T>
{
    public NonRepeatableList()
    {
        customlList = new List<T>();
    }

    private int lastPrefabIndex = 0;
    public T NoRepeatRnd()
    {
        // Cria um index igual ao último
        int newIndex = lastPrefabIndex;

        // Enquanto esse index for igual ao último...
        while (newIndex == lastPrefabIndex)
        {
            // Cria um novo index aleatório
            newIndex = Random.Range(0, customlList.Count);
        }
        // Atualiza o index antigo
        lastPrefabIndex = newIndex;

        // Retorna o GameObject com o index gerado
        return customlList[newIndex];
    }

    public T ExclusionaryRnd()
    {
        if (customlList.Count <= 0)
            return default;

        int newIndex = Random.Range(0, customlList.Count);
        T obj = customlList[newIndex];
        customlList.RemoveAt(newIndex);

        return obj;
    }
}
