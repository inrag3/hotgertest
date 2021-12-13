using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Не останавливаю корутину, так как остановил все корутины при смерти шарики (возможно, не правильное решение)
public class ScoreHandler : MonoBehaviour
{
    private float _timeInGame;
    private float _attempts;

    public event Action<float, float> Received;
    
    private void Start()
    {
        StartCoroutine(TimeInGame());
    }

    private IEnumerator TimeInGame()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _timeInGame += 1;
        }
    }

    public void ReceiveScore()
    {
        ++_attempts;
        Received?.Invoke(_timeInGame,_attempts);
        _timeInGame = 0;
    }
}