using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] private UIController uiController;
    [SerializeField] private SettingsMenu settingsMenu;

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }

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
        uiController.SetGameActive(true);
        Close();
    }
}
