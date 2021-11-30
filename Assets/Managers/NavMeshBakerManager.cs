using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBakerManager : MonoBehaviour
{
    [SerializeField] private NavMeshSurface2d _navMeshSurface;

    [System.NonSerialized] public List<Collider2D> collidersToBake = new List<Collider2D>();
    /* We need to disable walkable area colliders (for grounds) because if colliders are enabled we can't walk on it */
    [System.NonSerialized] public List<Collider2D> collidersToDisableAfter = new List<Collider2D>();
    
    public static NavMeshBakerManager instance;

    void Awake()
    {
        instance = this;
    }

    public void BuildNavMesh()
    {
        /* First we need t o set myself (because I have nav mesh surface) as colliders parent because nav mesh surface bake his childs */
        foreach (Collider2D collider in collidersToBake)
            collider.transform.SetParent(transform);
        /* Now we have childs, we can bake */
        _navMeshSurface.BuildNavMesh();
        /* Now we can disable walkable area colliders */
        foreach (Collider2D collider in collidersToDisableAfter)
            collider.enabled = false;
    }
}
