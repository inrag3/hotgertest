
using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Obstacle : MonoBehaviour
{
    protected Collider2D _collider;
    protected Rigidbody2D _rigidbody;
    protected Transform _transform;


    public Transform Transform => _transform;
    public Rigidbody2D Rigidbody2D => _rigidbody;
    public Collider2D Collider2D => _collider;
    
    protected virtual void Awake()
    {
        _transform = GetComponent<Transform>();
        _collider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
}
