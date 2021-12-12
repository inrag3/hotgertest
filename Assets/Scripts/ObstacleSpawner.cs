
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Obstacle _obstaclePrefab;
    private List<Obstacle> _pool;
    private float _spawnFrequency;
    private Obstacle _obstacle;
    private float _minHeight;
    private float _maxHeight;
    
    public void Init(ISpawnable settings)
    {
        _spawnFrequency = settings.SpawnFrequency;
        _minHeight = settings.MinHeight;
        _maxHeight = settings.MaxHeight;
    }

    
    //Можно было бы реализовать с помощью корутины.
    private void Update()
    {
        _obstacle = Instantiate(_obstaclePrefab);
        _obstacle.transform.position = new Vector2(500,Random.Range(_minHeight, _maxHeight));
    }
    
}
