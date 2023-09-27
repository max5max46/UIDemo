using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void LoadGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public static void ExitGame()
    {
        Application.Quit();
    }

}
