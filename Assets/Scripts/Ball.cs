using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private float _speed;

    public event Action Died;

    public void Init(IBallSettings ballSettings)
    {
        _speed = ballSettings.BallSpeed;
    }

    public void IncreaseSpeed(int value)
    {
        _speed += value;
    }

    public void MoveHorizontal()
    {
        _rigidbody2D.velocity = new Vector2(_speed, 0);
    }

    public void MoveVertical()
    {
        _rigidbody2D.velocity = new Vector2(0, _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out WallSlider wallSlider))
            Died?.Invoke();
    }
}