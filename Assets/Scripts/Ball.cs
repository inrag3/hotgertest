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

    public float Speed { get; private set; }

    public void Init(IBallSettings ballSettings)
    {
        Speed = ballSettings.BallSpeed;
    }

    public void IncreaseSpeed(int value)
    {
        Speed += value;
    }

    public void Move()
    {
        _rigidbody2D.velocity = new Vector2(Speed*Time.deltaTime,0);
    }
}