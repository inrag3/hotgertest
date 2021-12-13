
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Obstacle _obstaclePrefab;
    private List<Obstacle> _activeObstacles;
    private float _spawnFrequency;
    private Obstacle _obstacle;
    private float _minHeight;
    private float _maxHeight;

    public void Init(ISpawnable settings)
    {
        _activeObstacles = new List<Obstacle>();
        _spawnFrequency = settings.SpawnFrequency;
        _minHeight = settings.MinHeight;
        _maxHeight = settings.MaxHeight;
        StartCoroutine(Spawn(_spawnFrequency));
    }
    
    // public void AddToPool(Obstacle obstacle)
    // {
    //     obstacle.gameObject.SetActive(false);
    //     _pool.Add(obstacle);
    // }

    private IEnumerator Spawn(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            _obstacle = Instantiate(_obstaclePrefab);
            _activeObstacles.Add(_obstacle);
            _obstacle.transform.position = new Vector3(10,Random.Range(_minHeight, _maxHeight),0);
        }
    }

    //Нужно вынести в отдельный класс не подходит по логике.
    public void ClearActive()
    {
        StopAllCoroutines();
        foreach (var x in _activeObstacles)
        {
            if (x != null)
            {
                Destroy(x.gameObject);
            }
        }
        _activeObstacles.Clear();
    }
}
