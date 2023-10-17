using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallDamage : MonoBehaviour
{
    private Color colorChange;
    private bool showBlood = false;
    [SerializeField] private RawImage bloodUI;
    // Start is called before the first frame update
    void Start()
    {
        colorChange = bloodUI.color;
        Debug.Log(colorChange.ToString());
        bloodUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (showBlood)
        {
            colorChange.a -= 0.01f;
            bloodUI.color = colorChange;

            if (colorChange.a <= 0)
            {
                bloodUI.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("hit");
        if (!showBlood) 
        {
            if (collision.gameObject.tag == "Player")
            {
                
                ProgramManager.RemoveHealth(2);
                bloodUI.gameObject.SetActive(true);
                colorChange.a = 1f;
                bloodUI.color = colorChange;
                showBlood = true;
            }
        }
    }
}
