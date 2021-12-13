using System;
using System.Collections;
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
        MoveHorizontal();
        StartCoroutine(IncreaseHorizontalSpeed(_ball.IncreaseSpeedTime));
    }

    public void MoveVertical()
    {
        _ball.Rigidbody2D.velocity = Vector2.up * _ball.Speed.y;
    }

    public void MoveHorizontal()
    {
        _ball.Rigidbody2D.velocity = Vector2.right * _ball.Speed.x;
    }
    
    
    //Каждые N секунд горизонтальная скорость шарика должна увеличиваться.
    private IEnumerator IncreaseHorizontalSpeed(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            _ball.Rigidbody2D.velocity += Vector2.right / 10;
        }
    }


    private void OnBallDied()
    {
        //Возможно стоило сделать метод Init и прокинуть туда Ивент, появления UI
        Destroy(_ball.gameObject);
        BallDied?.Invoke();
    }
}