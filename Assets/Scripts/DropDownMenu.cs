//Первый раз работаю с DropDown

using System;
using UnityEngine;

public class DropDownMenu : MonoBehaviour
{
    [SerializeField] private Settings _easySettings;
    [SerializeField] private Settings _mediumSettings;
    [SerializeField] private Settings _hardSettings;

    public Settings Settings { get; private set; }

    private void OnEnable()
    {
        Settings = _easySettings;
    }

    public void GetSettings(int n)
    {
        Settings = n switch
        {
            0 => _easySettings,
            1 => _mediumSettings,
            2 => _hardSettings,
            _ => Settings
        };
    }
}