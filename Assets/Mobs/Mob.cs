using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mob : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float       _speed = 3;

    public static Transform target;

    void Update()
    {
        if (target != null)
        {
            NavMeshPath navMeshPath = new NavMeshPath();
            if (NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, navMeshPath) && navMeshPath.status == NavMeshPathStatus.PathComplete)
            {
                if (navMeshPath.corners.Length > 0)
                {
                    /* navMeshPath.corners[0] == transform.position */
                    Vector2 direction = navMeshPath.corners[1] - transform.position;
                    Move(direction);
                }
                /* For debug in scene view */
                for (int i = 0; i < navMeshPath.corners.Length - 1; i++)
                    Debug.DrawLine(navMeshPath.corners[i], navMeshPath.corners[i + 1], Color.blue);
            }
        }
    }

    private void Move(Vector2 direction) => _rigidbody.velocity = direction.normalized * _speed;
    
}
