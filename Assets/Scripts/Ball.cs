using System;

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Ball : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D { get; private set; }
    private float _speed;

    public event Action Died;

    public void Init(IBallSettings ballSettings)
    {
        _speed = ballSettings.BallSpeed;
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Obstacle deadly))
            Died?.Invoke();
    }
}