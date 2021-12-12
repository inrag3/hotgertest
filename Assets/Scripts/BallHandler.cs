
using System;
using UnityEngine;


//Наверно можно убрать MonoBehavior, и прокидывать префаб через GameHandler.
public class BallHandler : MonoBehaviour
{
    [SerializeField] private Ball _ballPrefab;
    private Ball _ball;

    public event Action BallDied;
    
    
    public void SpawnBall(IBallSettings ballSettings)
    {
        _ball = Instantiate(_ballPrefab);
        _ball.Init(ballSettings);
        _ball.Died += OnBallDied;
        _ball.MoveHorizontal();
    }

    private void OnBallDied()
    {
        //Возможно стоило сделать метод Init и прокинуть туда Ивент, появления UI
        BallDied?.Invoke();
    }
}
