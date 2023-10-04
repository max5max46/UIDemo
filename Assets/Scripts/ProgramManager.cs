using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgramManager : MonoBehaviour
{

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public static void WinLevel()
    {
        PauseGame();
        FindAnyObjectByType(typeof(FirstPersonController_Sam)).GetComponent<FirstPersonController_Sam>().canMove = false;

        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            FindAnyObjectByType(typeof(MenuManager)).GetComponent<MenuManager>().ChangeMenu(4);
        else
            FindAnyObjectByType(typeof(MenuManager)).GetComponent<MenuManager>().ChangeMenu(8);
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
