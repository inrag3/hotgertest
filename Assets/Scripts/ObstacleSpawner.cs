
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
    private float _spawnFrequency;
    private Obstacle _obstacle;
    private float _minHeight;
    private float _maxHeight;

    public event Action<Obstacle> Spawned;
    
    public void Init(ISpawnable settings)
    {
        _pool = new Stack<Obstacle>();
        _spawnFrequency = settings.SpawnFrequency;
        _minHeight = settings.MinHeight;
        _maxHeight = settings.MaxHeight;
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
            _obstacle.transform.localPosition = new Vector3(10,Random.Range(_minHeight, _maxHeight),0);
        }
    }

    //Нужно вынести в отдельный класс не подходит по логике.
    public void ClearActive()
    {
        StopAllCoroutines();
        // foreach (var x in _activeObstacles)
        // {
        //     if (x != null)
        //     {
        //         Destroy(x.gameObject);
        //     }
        // }
        // _activeObstacles.Clear();
    }
}
