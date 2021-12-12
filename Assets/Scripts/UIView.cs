
using UnityEngine;

public class UIPresenter : MonoBehaviour
{
    [SerializeField] public GameObject _gameOverScreen;
    
    public void LoadGameOverScreen()
    {
        _gameOverScreen.SetActive(false);
    }
}
