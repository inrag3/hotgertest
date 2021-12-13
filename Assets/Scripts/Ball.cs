using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Ball : MonoBehaviour
{
    public  Rigidbody2D Rigidbody2D;
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