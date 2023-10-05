using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UIElements;

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

    public static int CheckScene() 
    {
        Scene currentScene = SceneManager.GetActiveScene();
        return currentScene.buildIndex;
    }

    public static void ExitGame()
    {
        Application.Quit();
    }

    public void DeleteSaveData()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            FindAnyObjectByType(typeof(MenuManager)).GetComponent<MenuManager>().DisplayCornerText("Save File Deleted");
            File.Delete(Application.persistentDataPath + "/playerInfo.dat");
        }
        else
        {
            FindAnyObjectByType(typeof(MenuManager)).GetComponent<MenuManager>().DisplayCornerText("No Save File Found");
        }

    }

    public void Save()
    {
        FindAnyObjectByType(typeof(MenuManager)).GetComponent<MenuManager>().DisplayCornerText("Game Saved");

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.sceneIndex = SceneManager.GetActiveScene().buildIndex;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            FindAnyObjectByType(typeof(MenuManager)).GetComponent<MenuManager>().DisplayCornerText("Game Loaded");

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            SceneManager.LoadScene(data.sceneIndex);
            FindAnyObjectByType(typeof(MenuManager)).GetComponent<MenuManager>().ChangeMenu(0);
        }
        else
        {
            FindAnyObjectByType(typeof(MenuManager)).GetComponent<MenuManager>().DisplayCornerText("No Save File Found");
        }
    }
}
[Serializable]
class PlayerData
{
    public int sceneIndex;
}
