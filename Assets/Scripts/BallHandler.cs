
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
    }

    public void MoveVertical()
    {
        _ball.Rigidbody2D.velocity = Vector2.up * 3f;
    }
    
    private void OnBallDied()
    {
        //Возможно стоило сделать метод Init и прокинуть туда Ивент, появления UI
        BallDied?.Invoke();
    }
}
