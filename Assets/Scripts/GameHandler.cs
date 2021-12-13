
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private BallHandler _ballHandler;
    [SerializeField] private UIPresenter _uiView;
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private ObstacleMover _obstacleMover;
    [SerializeField] private ScoreHandler _scoreHandler;
    private float _timeInGame;
    private float _attempts;
    
    private void Awake()
    {
        StopGame();
        _ballHandler.BallDied += OnBallDied;
        _uiView.ClickedUpButton += OnUpClicked;
        _uiView.StartClicked += OnStartClicked;
        _scoreHandler.Received += OnReceived;
        //_obstacleMover.OutOfScreen += OnOutOfScreen;
    }

    private void OnReceived(float arg1, float arg2)
    {
        _timeInGame = arg1;
        _attempts = arg2;
    }

    private void OnStartClicked(Settings settings)
    {
        Init(settings);
    }

    private void Init(Settings settings)
    {
        StartGame();
        _ballHandler.SpawnBall(settings);
        _obstacleSpawner.Init(settings);
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }

    private void StopGame()
    {
        Time.timeScale = 0;
    }
    
    private void OnUpClicked()
    {
        _ballHandler.MoveVertical();
    }

    // private void OnOutOfScreen(Obstacle obstacle)
    // {
    //     _obstacleSpawner.AddToPool(obstacle);
    // }

    private void OnDisable()
    {
        _ballHandler.BallDied -= OnBallDied;
        _uiView.ClickedUpButton -= OnUpClicked;
        _uiView.StartClicked -= OnStartClicked;
    }
    
    private void OnBallDied()
    {
        StopGame();
        _scoreHandler.ReceiveScore();
        _uiView.ActiveGameOverScreen(_timeInGame,_attempts);
        _obstacleSpawner.ClearActive();
    }
}
