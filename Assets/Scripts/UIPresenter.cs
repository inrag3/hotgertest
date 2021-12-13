
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private Button _upButton;
    [SerializeField] private Button _startButton;
    [SerializeField] private DropDownMenu _dropDownMenu;
    [SerializeField] private Button _startAgain;
    [SerializeField] private DropDownMenu _gameDropDownMenu;
    public event Action ClickedUpButton;
    public event Action<Settings> ClickedStartButton;
    private void Start()
    {
        _upButton.onClick.AddListener(OnUpClicked);
        _startButton.onClick.AddListener(OnStartClicked);
        _startAgain.onClick.AddListener(OnStartAgainClicked);
    }

    private void OnStartAgainClicked()
    {
        _gameOverScreen.SetActive(false);
        ClickedStartButton?.Invoke(_gameDropDownMenu.Settings);
    }

    private void OnStartClicked()
    {
        _startScreen.SetActive(false);
        ClickedStartButton?.Invoke(_dropDownMenu.Settings);
    }
    
    private void OnUpClicked()
    {
        ClickedUpButton?.Invoke();
    }

    public void ActiveGameOverScreen()
    {
        _gameOverScreen.SetActive(true);
    }
    
}
