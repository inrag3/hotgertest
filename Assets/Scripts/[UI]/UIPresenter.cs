
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIPresenter : MonoBehaviour
{
    [SerializeField] private GameOverView _gameOverScreen;
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private Button _upButton;
    [SerializeField] private Button _startButton;
    [SerializeField] private DropDownMenu _dropDownMenu;
    private Settings _currentSettings;
    
    public event Action<Settings> StartClicked;
    public event Action ClickedUpButton;
    
    private void OnEnable()
    {
        _upButton.onClick.AddListener(OnUpClicked);
        _startButton.onClick.AddListener(OnStartClicked);
        _gameOverScreen.ClickedStartButton += OnStartAgainClicked;
    }

    private void OnStartAgainClicked(Settings settings)
    {
        StartClicked?.Invoke(settings);
    }

    private void OnStartClicked()
    {
        _startScreen.SetActive(false);
        print(_dropDownMenu.GetSettings());
        StartClicked?.Invoke(_dropDownMenu.GetSettings());
    }
    
    private void OnUpClicked()
    {
        ClickedUpButton?.Invoke();
    }

    public void ActiveGameOverScreen(float timeInGame, float attempts)
    {
        _gameOverScreen.Active(timeInGame, attempts);
    }
}
