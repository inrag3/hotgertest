
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TilemapCollider2D))]
public class Wall : Obstacle
{
    protected override void Awake()
    {
        base.Awake();
        _collider = GetComponent<TilemapCollider2D>();
    }
}

