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

    public static string CheckScene() 
    {
        Scene currentScene = SceneManager.GetActiveScene();
        return currentScene.name;
    }

    public static void ExitGame()
    {
        Application.Quit();
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.x = FindAnyObjectByType(typeof(FirstPersonController_Sam)).GameObject().transform.position.x;
        data.z = FindAnyObjectByType(typeof(FirstPersonController_Sam)).GameObject().transform.position.z;
        data.y = FindAnyObjectByType(typeof(FirstPersonController_Sam)).GameObject().transform.position.y;
        data.sceneIndex = SceneManager.GetActiveScene().buildIndex;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            SceneManager.LoadScene(data.sceneIndex);
            FindFirstObjectByType(typeof(FirstPersonController_Sam)).GameObject().transform.position = new Vector3 (data.x, data.y, data.z);
        }
    }
}
[Serializable]
class PlayerData
{
    public int sceneIndex;
    public float x;
    public float y;
    public float z;
}
