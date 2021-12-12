
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TilemapCollider2D),typeof(Rigidbody2D))]
public class Wall : MonoBehaviour
{
    private TilemapCollider2D _tilemapCollider2D;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _tilemapCollider2D = GetComponent<TilemapCollider2D>();
    }
    
    
    
    
}
