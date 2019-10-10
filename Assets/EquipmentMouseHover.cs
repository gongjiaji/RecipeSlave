using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipmentMouseHover : MonoBehaviour
{
    private string itemName;
    private string description;
    private string description2;
    private string description3;
    private string description4;
    private GameObject[] allItems;
    private GameObject itemObject;
    public GameObject itemInfoPanel;
    private Sprite sprite;
    private TextMeshProUGUI text;
    private TextMeshProUGUI text2;
    private TextMeshProUGUI text3;
    private TextMeshProUGUI text4;
    private float x;
    public bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("ItemInfoText_name").GetComponent<TextMeshProUGUI>();
        text2 = GameObject.Find("ItemInfoText_effect1").GetComponent<TextMeshProUGUI>();
        text3 = GameObject.Find("ItemInfoText_effect2").GetComponent<TextMeshProUGUI>();
        text4 = GameObject.Find("ItemInfoText_description").GetComponent<TextMeshProUGUI>();
        isOn = false;
        itemInfoPanel = GameObject.Find("ItemInfoPanel");

    }

    void OnMouseOver() {
        isOn = true;
        if(this.CompareTag("ItemBoarder")) {
            // this is a itemboarder, the object is the first child
            itemObject = this.gameObject.transform.GetChild(0).gameObject;
            itemName = itemObject.GetComponent<SpriteRenderer>().sprite.name;
            sprite = itemObject.GetComponent<SpriteRenderer>().sprite;


        }
        else { // it's on equipment panel
            itemObject = this.gameObject;
            itemName = itemObject.GetComponent<Image>().sprite.name;
            sprite = itemObject.GetComponent<Image>().sprite;

        }
        FindItem();
        SwtichPanel(true);
    }

    void OnMouseExit() {
        isOn = false;
        Debug.Log("Mouse is no longer on GameObject.");
        SwtichPanel(false);


    }

    private void FindItem() {
        allItems = GameObject.FindGameObjectsWithTag("food");
        foreach(GameObject item in allItems) {
            if(item.GetComponent<SpriteRenderer>().sprite.name.Equals(itemName)) {
                description = item.GetComponent<Item>().describtion;
                description2 = item.GetComponent<Item>().describtion2;
                description3 = item.GetComponent<Item>().describtion3;
                description4 = item.GetComponent<Item>().describtion4;
                // change backgroud iamge
                itemInfoPanel.GetComponent<Image>().sprite = sprite;
                // apply new item text
                text.text = description;
                text2.text = description2;
                text3.text = description3;
                text4.text = description4;
            }
        }
    }

    private void SwtichPanel(bool state) {
        int x;
        if(state) {
            x = 1;
        }
        else {
            x = 0;
        }
        itemInfoPanel.GetComponent<RectTransform>().localScale = new Vector3(x,
        itemInfoPanel.GetComponent<RectTransform>().localScale.y,
        itemInfoPanel.GetComponent<RectTransform>().localScale.z);
    }
}
