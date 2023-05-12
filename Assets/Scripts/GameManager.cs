using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _settingsPanel;

    public void SettingsButton()
    {
        _settingsPanel.SetActive(!_settingsPanel.activeInHierarchy);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
