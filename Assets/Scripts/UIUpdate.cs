using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIUpdate : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Slider healthSlider;
    public TextMeshProUGUI staminaText;
    public Image staminaWheel;
    public TextMeshProUGUI xp;
    public TextMeshProUGUI score;
    public TextMeshProUGUI gmCount;


    // Start is called before the first frame update
    void Start()
    {
        healthText.text = ProgramManager.health + "/" + ProgramManager.maxHealth;
        healthSlider.maxValue = ProgramManager.maxHealth;
        healthSlider.value = ProgramManager.maxHealth;
        staminaText.text = ProgramManager.stamina + "";
        staminaWheel.fillAmount = ProgramManager.stamina/ProgramManager.maxStamina;
        xp.text = "Xp: " + ProgramManager.xp;
        score.text = "Score: " + ProgramManager.score;
        gmCount.text = "# of Game Managers: " + GameManagerTracker.gameManagerCount;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = ProgramManager.health + "/" + ProgramManager.maxHealth;
        healthSlider.value = ProgramManager.health;
        

        if (ProgramManager.stamina < 2)
        {
            staminaWheel.fillAmount = 0;
            staminaText.text = "0";
        }
        else
        {
            staminaWheel.fillAmount = ProgramManager.stamina / ProgramManager.maxStamina;
            staminaText.text = (float)Math.Round(ProgramManager.stamina) + "";
        }

        xp.text = "Xp: " + ProgramManager.xp;
        score.text = "Score: " + ProgramManager.score;
        gmCount.text = "# of Game Managers: " + GameManagerTracker.gameManagerCount;
    }
}
