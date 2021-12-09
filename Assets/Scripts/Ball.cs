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
    
    public void Init(IBallSettings ballSettings)
    {
        _speed = ballSettings.BallSpeed;
    }
}

