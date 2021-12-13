
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIPresenter : MonoBehaviour
{
    [SerializeField] public GameObject _gameOverScreen;
    [SerializeField] public Button _button;

    public event Action Clicked;
    
    private void Start()
    {
        _button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        Clicked?.Invoke();
    }
    
    public void LoadGameOverScreen()
    {
        _gameOverScreen.SetActive(false);
    }
}
