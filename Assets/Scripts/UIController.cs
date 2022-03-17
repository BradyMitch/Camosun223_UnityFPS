using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreValue;

    [SerializeField] private Image healthBar;

    [SerializeField] private Image crossHair;

    [SerializeField] private OptionsMenu optionsMenu;
    [SerializeField] private SettingsMenu settingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(score);
        healthBar.fillAmount = 1;
        healthBar.color = Color.green;

        SetGameActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsMenu.IsActive() && !settingsMenu.IsActive())
        {
            SetGameActive(false);
            optionsMenu.Open();
        }
    }

    // update score display 
    public void UpdateScore(int newScore)
    {
        scoreValue.text = newScore.ToString();
    }

    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1;                        // unpause the game 
            Cursor.lockState = CursorLockMode.Locked;  // show the cursor 
            crossHair.gameObject.SetActive(true);      // show the crosshair 
        }
        else
        {
            Time.timeScale = 0;                       // pause the game 
            Cursor.lockState = CursorLockMode.None;   // show the cursor 
            crossHair.gameObject.SetActive(false);    // turn off the crosshair 
        }
    }
}
