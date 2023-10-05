using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdate : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI xp;
    public TextMeshProUGUI score;
    public TextMeshProUGUI gmCount;

    // Start is called before the first frame update
    void Start()
    {
        health.text = "Health: " + ProgramManager.health;
        xp.text = "Xp: " + ProgramManager.xp;
        score.text = "Score: " + ProgramManager.score;
        gmCount.text = "# of Game Managers: " + GameManagerTracker.gameManagerCount;
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + ProgramManager.health;
        xp.text = "Xp: " + ProgramManager.xp;
        score.text = "Score: " + ProgramManager.score;
        gmCount.text = "# of Game Managers: " + GameManagerTracker.gameManagerCount;
    }
}
