using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCAssembly : Task
{
    [SerializeField] private List<Transform> transformsObjs;

    private void Start()
    {
        foreach (var transform in transformsObjs)
        {
            transform.position = SpawnObjects.instance.RandomHideSpawn().position;
        }
    }
}
