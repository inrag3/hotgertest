
using System;
using UnityEngine;

public class MoveHandler : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Settings _settings;


    private void Awake()
    { 
        Instantiate(_ball);
    }
}
