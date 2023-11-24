using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private List<Transform> posHideSpawns;

    public static SpawnObjects instance;
    private void Awake()
    {
        instance = this;
    }

    public Transform RandomHideSpawn()
    {
        return posHideSpawns[Random.Range(0, posHideSpawns.Count)].transform;
    }
}
