﻿
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings")]
public class Settings : ScriptableObject, IBallSettings, ISpawnable
{
    [SerializeField] private float _ballSpeed;
    [SerializeField] private float _increaseSpeedTime;
    [SerializeField] private float _spawnCells;
    [SerializeField] private float _spawnFrequency;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    
    public float BallSpeed => _ballSpeed;
    public float IncreaseSpeedTime => _increaseSpeedTime;
    public float SpawnCells => _spawnCells;
    public float SpawnFrequency => _spawnFrequency;
    
    public float MinHeight => _minHeight;
    public float MaxHeight => _maxHeight;
}

public interface ISpawnable
{
    float SpawnFrequency { get; }
    float MinHeight { get; }
    float MaxHeight { get; }
}
