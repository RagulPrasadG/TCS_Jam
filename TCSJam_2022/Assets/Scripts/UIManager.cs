using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    //How to Play
    [SerializeField] GameObject howToplayPanel;

    //MainMenu
    [SerializeField] GameObject mainMenuPanel;

    //GameOver
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Volume bgBlur;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void EnableGameOverPanel()
    {
        TogglePanel(gameOverPanel, true);
        bgBlur.weight = 1;
    }

    //Called by button events
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void PlayGame()
    {
        TogglePanel(mainMenuPanel, false);
        Time.timeScale = 1;
    }

    public void EnableMainMenu()
    {
        TogglePanel(mainMenuPanel, true);
        TogglePanel(gameOverPanel, false);
    }
    public void DisplayGameplayMechanics()
    {
        TogglePanel(mainMenuPanel, false);
        TogglePanel(howToplayPanel, true);
    }
    public void CloseGameplayMechanics()
    {
        TogglePanel(mainMenuPanel, true);
        TogglePanel(howToplayPanel, false);
    }

    public void QuitGame()  => Application.Quit();
    private void TogglePanel(GameObject panel,bool setActive) => panel.SetActive(setActive);
   
}
