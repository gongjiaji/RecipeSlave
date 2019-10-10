using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatManager : MonoBehaviour
{
    private CharController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharController>();
    }

    // Update is called once per frame
    void Update()
    {
        string sprite = GetComponent<Image>().sprite.name;
        switch(sprite) {
            case "hatBlue":
            cc.skill1Attack = 2;
            break;

            case "hatBlack":
            cc.skill1Attack = 3;
            break;
        }
    }
}
