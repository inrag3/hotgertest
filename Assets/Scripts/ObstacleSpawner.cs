
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Obstacle _obstaclePrefab;
    private Stack<Obstacle> _pool;
    private List<Obstacle> _activeObstacles; 
    private float _spawnFrequency;
    private Obstacle _obstacle;
    private float _minHeight;
    private float _maxHeight;
    private float _rightBorder;
    public event Action<Obstacle> Spawned;
    
    public void Init(ISpawnable settings, float rightBorder)
    {
        _pool = new Stack<Obstacle>();
        _activeObstacles = new List<Obstacle>();
        _spawnFrequency = settings.SpawnFrequency;
        _minHeight = settings.MinHeight;
        _maxHeight = settings.MaxHeight;
        _rightBorder = rightBorder;
        StartCoroutine(Spawn(_spawnFrequency));
    }
    
    public void AddToPool(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(false);
        _pool.Push(obstacle);
    }
    
    private IEnumerator Spawn(float time)
    {
       
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (_pool.Count == 0)
            {
                _obstacle = Instantiate(_obstaclePrefab);
                Spawned?.Invoke(_obstacle);
            }
            else
            {
                _obstacle = _pool.Pop();
                _obstacle.gameObject.SetActive(true);
            }
            if (!_activeObstacles.Contains(_obstacle))
                _activeObstacles.Add(_obstacle);
            _obstacle.Transform.localPosition = new Vector3(_rightBorder + _obstacle.Collider2D.bounds.size.x ,Random.Range(_minHeight, _maxHeight),0);
        }
    }

    //Можно вынести в отдельный класс не подходит по логике (ObstacleSpawner).
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
