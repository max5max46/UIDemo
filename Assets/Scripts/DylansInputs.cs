using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DylansInputs : MonoBehaviour
{
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private MusicManager musicManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuManager.CheckState() == 9)
            Pause();
        else if (Input.GetKeyDown(KeyCode.Escape) && menuManager.CheckState() == 3)
            Resume();
    }

    public void Pause()
    {
        menuManager.ChangeMenu(3);
        musicManager.StopMusic();
        ProgramManager.PauseGame();
        FindAnyObjectByType(typeof(FirstPersonController_Sam)).GetComponent<FirstPersonController_Sam>().canMove = false;
    }

    public void Resume()
    {
        menuManager.ChangeMenu(9);
        musicManager.PlayMusic();
        ProgramManager.ResumeGame();
        FindAnyObjectByType(typeof(FirstPersonController_Sam)).GetComponent<FirstPersonController_Sam>().canMove = true;
    }
}
