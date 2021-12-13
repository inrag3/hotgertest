
using System;

using UnityEngine;


[RequireComponent(typeof(Obstacle))]
public class ObstacleMover : MonoBehaviour
{
    private Obstacle _obstacle;

    //public event Action<Obstacle> OutOfScreen;
    
    private void Awake()
    {
        _obstacle = GetComponent<Obstacle>();
        _obstacle.Rigidbody2D.velocity = Vector2.left * 5f;
    }

    private void Update()
    {
        if (_obstacle.Collider2D.transform.position.x < -10f)
        {
            Destroy(_obstacle.gameObject);
            //OutOfScreen?.Invoke(_obstacle);
        }
    }
}