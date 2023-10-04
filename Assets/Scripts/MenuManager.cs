using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public enum MenuState
    {
        None,
        Main,
        Options,
        Pause,
        Win,
        Lose,
        Credits,
        LevelSelect,
        LevelWin
    }

    private MenuState state;

    public GameObject mainMenu;
    public GameObject levelSelect;
    public GameObject optionsMenu;
    public GameObject pauseMenu;
    public GameObject levelWinScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject creditsScreen;

    // Start is called before the first frame update
    void Start()
    {
        ChangeMenu((int)MenuState.Main);
    }

    public void ChangeMenu(int state) 
    {
        this.state = (MenuState)state;

        mainMenu.SetActive(false);
        levelSelect.SetActive(false);
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        levelWinScreen.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        creditsScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        switch (this.state)
        {
            case MenuState.None:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;

            case MenuState.Main:
                mainMenu.SetActive(true);
                break;

            case MenuState.LevelSelect:
                levelSelect.SetActive(true);
                break;

            case MenuState.Options:
                optionsMenu.SetActive(true);
                break;

            case MenuState.Pause:
                pauseMenu.SetActive(true);
                break;

            case MenuState.LevelWin:
                levelWinScreen.SetActive(true);
                break;

            case MenuState.Win:
                winScreen.SetActive(true);
                break;

            case MenuState.Lose:
                loseScreen.SetActive(true);
                break;

            case MenuState.Credits:
                creditsScreen.SetActive(true);
                break;
        }
    }

    public void OptionsButton()
    {
        if (ProgramManager.CheckScene() == "MainMenu")
        {
            ProgramManager.ResumeGame();
            ChangeMenu(1);
        }
        else
        {
            if (ProgramManager.CheckScene() == "Gameplay")
            {
                ChangeMenu(3);
            }
        }
    }

    public int CheckState()
    {
        return (int)state;
    }
}
