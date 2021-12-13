using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DropDownMenu : MonoBehaviour
{
    [SerializeField] private Settings _easySettings;
    [SerializeField] private Settings _mediumSettings;
    [SerializeField] private Settings _hardSettings;
    private Dropdown _dropdown;
    
    private Settings _settings;
    
    public Action<Settings> Changed;
    
    private void Start()
    {
        _dropdown = GetComponent<Dropdown>();
    }

    public void SetValue(Settings settings)
    {
        print((int)settings.Complexity);
        GetComponent<Dropdown>().value = (int)settings.Complexity;
    }
    
    public Settings GetSettings()
    {
        _settings = _dropdown.value switch
        {
            0 => _easySettings,
            1 => _mediumSettings,
            2 => _hardSettings,
            _ => _settings
        };
        return _settings;
    }
}