
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings")]
public class Settings : ScriptableObject, IBallSettings
{
    [SerializeField] private float _ballSpeed;
    [SerializeField] private float _increaseSpeedTime;
    [SerializeField] private float _spawnCells;
    public float BallSpeed => _ballSpeed;
    public float IncreaseSpeedTime => _increaseSpeedTime;
    public float SpawnCells => _spawnCells;
}
