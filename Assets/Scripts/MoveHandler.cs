
using System;
using UnityEngine;

public class MoveHandler : MonoBehaviour
{
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private Settings _settings;

    private Ball _ball;
    
    private void Awake()
    { 
        _ball = Instantiate(_ballPrefab);
        _ball.Init(_settings);
    }
    
    private void Update()
    {
        _ball.Move();
    }
}
