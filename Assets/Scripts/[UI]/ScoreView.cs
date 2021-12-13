
using UnityEngine;
using UnityEngine.UI;
public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text _timeInGameText;
    [SerializeField] private Text _attemptsText;
    
    public void UpdateText(float timeInGame, float attempts)
    {
        _timeInGameText.text = $"Продолжительность последний попытки: {timeInGame} секунд";
        _attemptsText.text = $"Количество попыток: {attempts}";
    }
}
