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

    public static int maxHealth = 10;
    public static int health;
    public static float maxStamina = 100;
    public static float stamina;
    public static int xp = 0;
    public static int score = 0;
    private static FirstPersonController_Sam player;
    private static bool canRun = true; 
    private static bool runCoolDown;



    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
    }

    void Update()
    {

        if (player != null)
        {
            if (player.isRunning)
                RemoveStamina(1 * Time.deltaTime * 30);
            else
                AddStamina(1 * Time.deltaTime * 45);

            if (stamina > 0.001 * maxStamina && runCoolDown == false)
                player.canRun = true;
            else
            {
                player.canRun = false;
                runCoolDown = true;
            }

            if (stamina > maxStamina * 0.99)
                runCoolDown = false;
        }

    }

    public static void GivePlayer(FirstPersonController_Sam playerToGive)
    {
        player = playerToGive;
    }

    public static void AddStamina(float toAdd)
    {
        if (stamina < maxStamina)
            stamina += toAdd;
        if (stamina > maxStamina)
            stamina = maxStamina;
    }

    public static void RemoveStamina(float toRemove)
    {
        if (stamina > 0)
            stamina -= toRemove;
        if (stamina < 0)
            stamina = 0;
    }

    public static void AddHealth(int toAdd)
    {
        if (health < maxHealth)
            health += toAdd;
    }

    public static void RemoveHealth(int toRemove)
    {
        if (health > 0)
            health -= toRemove;
    }

    public static void AddXp(int toAdd)
    {
        if (xp < 100)
            xp += toAdd;
    }

    public static void RemoveXp(int toRemove)
    {
        if (xp > 0)
            xp -= toRemove;
    }

    public static void AddScore(int toAdd)
    {
        if (score < 10000)
            score += toAdd;
    }

    public static void RemoveScore(int toRemove)
    {
        if (score > 0)
            score -= toRemove;
    }

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
        AddScore(1000);
        PauseGame();
        player.canMove = false;

        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            FindAnyObjectByType(typeof(MenuManager)).GetComponent<MenuManager>().ChangeMenu(4);
        else
            FindAnyObjectByType(typeof(MenuManager)).GetComponent<MenuManager>().ChangeMenu(8);
    }

    public static void LoseGame()
    {
        StatReset();
        PauseGame();
        player.canMove = false;
        FindAnyObjectByType(typeof(MenuManager)).GetComponent<MenuManager>().ChangeMenu(5);
    }

    public static int CheckScene() 
    {
        Scene currentScene = SceneManager.GetActiveScene();
        return currentScene.buildIndex;
    }

    public static void StatReset()
    {
        health = 10;
        xp = 0;
        score = 0;
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
        data.health = health;
        data.xp = xp;
        data.score = score;

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
            health = data.health;
            xp = data.xp;
            score = data.score;
            FindAnyObjectByType(typeof(MenuManager)).GetComponent<MenuManager>().ChangeMenu(9);
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
    public int health;
    public int score;
    public int xp;
}
