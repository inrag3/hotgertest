
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private BallHandler _ballHandler;
    [SerializeField] private Settings _settings;
    [SerializeField] private UIPresenter _uiView;
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    private void OnEnable()
    {
        _ballHandler.SpawnBall(_settings);
        _ballHandler.BallDied += OnBallDied;
        _obstacleSpawner.Init(_settings);
    }
    
    private void OnDisable()
    {
        _ballHandler.BallDied -= OnBallDied;
    }
    
    private void OnBallDied()
    {
        Time.timeScale = 0;
        _uiView.LoadGameOverScreen();
    }
}
