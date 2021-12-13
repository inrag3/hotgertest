using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraBounds : MonoBehaviour
{
    private Camera _camera;
    public float Left { get; private set; }
    public float Right { get; private set; }
    
    private void Awake()
    {
        _camera = GetComponent<Camera>();
        var leftDown = _camera.ViewportToWorldPoint(new Vector2(0, 0));
        Left = leftDown.x;
        var rightUp = _camera.ViewportToWorldPoint(new Vector2(1, 1));
        Right = rightUp.x;
    }
}