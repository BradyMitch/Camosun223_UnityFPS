using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI difficultyLabel;
    [SerializeField] private Slider difficultySlider;

    [SerializeField] private OptionsMenu optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnOkButton()
    {
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
        optionsMenu.Open();
        Close();
    }

    public void OnCancelButton()
    {
        optionsMenu.Open();
        Close();
    }

    public void UpdateDifficulty(float difficulty)
    {
        difficultyLabel.text = "Difficulty: " +((int)difficulty).ToString();
    }

    public void OnDifficultyValueChanged(float difficulty)
    {
        UpdateDifficulty(difficulty);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
