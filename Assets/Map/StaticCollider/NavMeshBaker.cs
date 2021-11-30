using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshBaker : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    /* For walkable area like grounds */
    [SerializeField] private bool       _disableColliderAfterBaking = false;

    void Awake()
    {
        if (_collider)
        {
            NavMeshBakerManager.instance.collidersToBake.Add(_collider);
            if (_disableColliderAfterBaking)
                NavMeshBakerManager.instance.collidersToDisableAfter.Add(_collider);
        }
    }
}
