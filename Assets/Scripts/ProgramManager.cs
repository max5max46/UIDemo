using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgramManager : MonoBehaviour
{

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void LoadGameplay()
    {
        SceneManager.LoadScene("Gameplay");
        FindAnyObjectByType(typeof(FirstPersonController_Sam)).GetComponent<FirstPersonController_Sam>().canMove = true;
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public static void WinGame()
    {
        PauseGame();
        FindAnyObjectByType(typeof(FirstPersonController_Sam)).GetComponent<FirstPersonController_Sam>().canMove = false;
        FindAnyObjectByType(typeof(MenuManager)).GetComponent<MenuManager>().ChangeMenu(4);
    }

    public static void LoseGame()
    {
        PauseGame();
        FindAnyObjectByType(typeof(FirstPersonController_Sam)).GetComponent<FirstPersonController_Sam>().canMove = false;
        FindAnyObjectByType(typeof(MenuManager)).GetComponent<MenuManager>().ChangeMenu(5);
    }

    public static string CheckScene() 
    {
        Scene currentScene = SceneManager.GetActiveScene();
        return currentScene.name;
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
}
