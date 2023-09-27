using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Credits
    }

    private MenuState state;

    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject pauseMenu;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject creditsScreen;

    // Start is called before the first frame update
    void Start()
    {
        ChangeMenu((int)MenuState.Main);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeMenu(int state) 
    {
        this.state = (MenuState)state;

        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        creditsScreen.SetActive(false);

        switch (this.state)
        {
            case MenuState.None:
                break;

            case MenuState.Main:
                mainMenu.SetActive(true);
                break;

            case MenuState.Options:
                optionsMenu.SetActive(true);
                break;

            case MenuState.Pause:
                pauseMenu.SetActive(true);
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
}
