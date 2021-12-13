
using System;
using UnityEngine;


[RequireComponent(typeof(Wall))]
public class WallMover : MonoBehaviour
{
    private Wall _wall;
    private void Start()
    {
        _wall = GetComponent<Wall>();
        _wall.Rigidbody2D.velocity = Vector2.left * 2f;
    } 

    private void Update()
    {
        if (_wall.Collider2D.transform.position.x < -20f)
        {
            _wall.Collider2D.transform.position = new Vector2(19f, 0);
        }
    }
}
