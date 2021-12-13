
using System;

using UnityEngine;

[RequireComponent(typeof(Obstacle))]
public class ObstacleMover : MonoBehaviour
{
    private Obstacle _obstacle;

    private float _leftBorder;
    
    public event Action<ObstacleMover> OutOfScreen;
    
    public void Init(float leftBorder, float rightBorder)
    {
        _leftBorder = leftBorder;
    }

    private void Awake()
    {
        _obstacle = gameObject.GetComponent<Obstacle>();
        Move();
    }

    public void Move()
    {
        _obstacle.Rigidbody2D.velocity = Vector2.left * 5f;
    }
    
    private void Update()
    {
        //Поставил сюда, потому что после доставания из пула обьектов, не получилась двинуть препятствие.
        Move();
        if (_obstacle.Transform.position.x < _leftBorder - _obstacle.Collider2D.bounds.size.x)
        {
            OutOfScreen?.Invoke(this);
        }
    }
}