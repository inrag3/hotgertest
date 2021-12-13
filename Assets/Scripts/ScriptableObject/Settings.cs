
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings")]
public class Settings : ScriptableObject, IBallSettings, ISpawnable
{
    [SerializeField] private Vector2 _ballSpeed;
    [SerializeField] private float _increaseSpeedTime;
    [SerializeField] private float _spawnFrequency;
    [SerializeField] [Range(-3.5f,3.5f)] private float _minHeight;
    [SerializeField] [Range(-3.5f,3.5f)] private float _maxHeight;
    [SerializeField] private Complexity _complexity;

    public Complexity Complexity => _complexity;
    public Vector2 BallSpeed => _ballSpeed;
    public float IncreaseSpeedTime => _increaseSpeedTime;
    public float SpawnFrequency => _spawnFrequency;
    
    
    
    public float MinHeight => _minHeight;
    public float MaxHeight => _maxHeight;
}



public enum Complexity
{
    Easy = 0,
    Medium,
    Hard,
}

