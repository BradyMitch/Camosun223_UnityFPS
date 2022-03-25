using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreValue;

    [SerializeField] private Image healthBar;

    [SerializeField] private Image crossHair;

    [SerializeField] private OptionsMenu optionsMenu;
    [SerializeField] private SettingsMenu settingsMenu;

    private int popupsOpen = 0;

    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, this.OnHealthChanged);
        Messenger.AddListener(GameEvent.POPUP_OPENED, this.OnPopupsOpened);
        Messenger.AddListener(GameEvent.POPUP_CLOSED, this.OnPopupsClosed);
    }

    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.HEALTH_CHANGED, this.OnHealthChanged);
        Messenger.AddListener(GameEvent.POPUP_OPENED, this.OnPopupsOpened);
        Messenger.AddListener(GameEvent.POPUP_CLOSED, this.OnPopupsClosed);
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        UpdateHealth(1f);

        SetGameActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && popupsOpen == 0)
        {
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
            Debug.Log("GameActive");
            Messenger.Broadcast(GameEvent.GAME_ACTIVE);
            Time.timeScale = 1;                        // unpause the game 
            Cursor.lockState = CursorLockMode.Locked;  // show the cursor 
            crossHair.gameObject.SetActive(true);      // show the crosshair 
        }
        else
        {
            Debug.Log("GameInActive");
            Messenger.Broadcast(GameEvent.GAME_INACTIVE);
            Time.timeScale = 0;                       // pause the game 
            Cursor.lockState = CursorLockMode.None;   // show the cursor 
            crossHair.gameObject.SetActive(false);    // turn off the crosshair 
        }
    }

    private void OnHealthChanged(float healthPercentage)
    {
        UpdateHealth(healthPercentage);
    }

    private void UpdateHealth(float healthPercentage)
    {
        healthBar.fillAmount = healthPercentage;
        healthBar.color = Color.Lerp(Color.red, Color.green, healthPercentage);
    }

    private void OnPopupsOpened()
    {
        if (popupsOpen == 0)
        {
            SetGameActive(false);
        }
        popupsOpen++;
    }

    private void OnPopupsClosed()
    {
        popupsOpen--;
        if (popupsOpen == 0)
        {
            SetGameActive(true);
        }
    }
}
