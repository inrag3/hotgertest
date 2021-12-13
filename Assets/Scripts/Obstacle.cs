
using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Obstacle : MonoBehaviour
{
    protected Collider2D _collider;
    protected Rigidbody2D _rigidbody;
    
    public Rigidbody2D Rigidbody2D => _rigidbody;
    public Collider2D Collider2D => _collider;
    
    protected virtual void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
}
