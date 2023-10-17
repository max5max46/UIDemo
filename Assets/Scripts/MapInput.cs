using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapInput : MonoBehaviour
{
    
    [SerializeField] private GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        map.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!map.activeInHierarchy) 
                map.SetActive(true);
            else
                map.SetActive(false);
        }
    }
}
