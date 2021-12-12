
using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Obstacle : MonoBehaviour
{
    protected Collider2D _boxCollider;
    protected Rigidbody2D _rigidbody;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
}
