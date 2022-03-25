using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : BasePopup
{

    [SerializeField] private SettingsMenu settingsMenu;

    public void OnSettingsButton()
    {
        Debug.Log("settings clicked");
        settingsMenu.Open();
        Close();
    }

    public void OnExitGameButton()
    {
        Debug.Log("exit game");
        Application.Quit();
    }

    public void OnReturnToGameButton()
    {
        Debug.Log("return to game");
        Close();
    }
}
