using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    [SerializeField] private GameObject             _mapPrefab;
    [SerializeField] private NavMeshBakerManager    _navMeshBakerManager;

    void Start()
    {
        /* Step 1: Generate map */
        Instantiate(_mapPrefab);

        /* Step 2: Bake */
        _navMeshBakerManager.BuildNavMesh();
    }
}
