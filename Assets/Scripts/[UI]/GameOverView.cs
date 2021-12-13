
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Button _startAgain;
    [SerializeField] private DropDownMenu _gameDropDownMenu;
    [SerializeField] private ScoreView _scoreView;
    public event Action<Settings> ClickedStartButton;

    private void Start()
    {
        _startAgain.onClick.AddListener(OnStartAgainClicked);
    }
    
    private void OnStartAgainClicked()
    {
        gameObject.SetActive(false);
        ClickedStartButton?.Invoke(_gameDropDownMenu.GetSettings());
    }

    public void SetDropDownValue(Settings settings)
    {
        _gameDropDownMenu.SetValue(settings);
    }
    
    public void Active(float timeInGame, float attempts)
    {
        _scoreView.UpdateText(timeInGame,attempts);
        gameObject.SetActive(true);
    }
}
