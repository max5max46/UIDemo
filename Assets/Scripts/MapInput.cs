using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MapInput : MonoBehaviour
{
    
    [SerializeField] private GameObject map;
    private RectTransform mapTrans;
    private float lerpTarget = -2000;
    private bool goingUp = false;

    // Start is called before the first frame update
    void Start()
    {
        mapTrans = map.GetComponent<RectTransform>();
        mapTrans.localPosition = new Vector3(0, lerpTarget, 0);
        map.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mapTrans.localPosition.x + " " + mapTrans.localPosition.y + " " + mapTrans.localPosition.z);
        Debug.Log(lerpTarget);

        if (Input.GetKeyDown(KeyCode.M))
            if (!goingUp)
            {
                lerpTarget = -96;
                goingUp = true;
            }
            else
            {
                lerpTarget = -2000;
                goingUp = false;
            }

        mapTrans.localPosition = new Vector3(0, Mathf.Lerp(mapTrans.localPosition.y, lerpTarget, Time.deltaTime * 10), 0);
    }
}
