using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEquipmentPanel : MonoBehaviour
{
    public GameObject panel;
    private float x;
    bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(isOn) {
            x = 300;
        }
        else {
            x = -550;
        }

        panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, panel.GetComponent<RectTransform>().anchoredPosition.y);
    }

    public void OnEquipButtonPressed() {
        isOn = !isOn;
        //panel.SetActive(isOn);
    }
}
