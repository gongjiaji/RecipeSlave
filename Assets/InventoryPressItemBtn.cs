using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPressItemBtn : MonoBehaviour
{
    public GameObject item;
    public Button button;
    private Sprite sprite;
    private BagManager bm;
    // Start is called before the first frame update
    void Start()
    {
        sprite = item.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(!bm) {
            bm = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<BagManager>();
        }
    }

    public void OnButtonPressed() {
        string id = "";
        switch(sprite.name) {
            case "Egg":
            id = "0001";
            break;

            case "Meat_Food":
            id = "0002";
            break;

            case "Rips":
            id = "0003";
            break;

            case "Meat":
            id = "0004";
            Debug.Log("Pressed Button 0004");
            break;

            case "Watermelon":
            id = "f01";
            break;

            case "hatBlue":
            id = "e01";
            break;

            case "hatBlack":
            id = "e02";
            break;

            case "woodClub":
            id = "w01";
            break;

            case "Hammer":
            id = "w02";
            break;

            case "00010001":
            id = "00010001";
            break;

            case "00010002":
            id = "00010002";
            break;

            case "00030004":
            id = "00030004";
            break;

            case "beer":
            id = "corona";
            break;

        }
        bm.UseAction(id);
    }
}
