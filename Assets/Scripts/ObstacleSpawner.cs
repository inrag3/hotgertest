
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        _pool = new List<Obstacle>();
        _spawnFrequency = settings.SpawnFrequency;
        _minHeight = settings.MinHeight;
        _maxHeight = settings.MaxHeight;
    }
    
    private void Start()
    {
        StartCoroutine(Spawn(_spawnFrequency));
    }
    
    public void AddToPool(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(false);
        _pool.Add(obstacle);
    }

    private IEnumerator Spawn(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (_pool.Count == 0)
                _obstacle = Instantiate(_obstaclePrefab);
            else _obstacle = _pool.First();
            _obstacle.transform.position = new Vector3(10,Random.Range(_minHeight, _maxHeight),0);
        }
    }
    
    
}
