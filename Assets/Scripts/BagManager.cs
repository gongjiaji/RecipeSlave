using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour {
    public Dictionary<string, int> items = new Dictionary<string, int>();
    private GameObject player;
    private CharController cc;
    public GameObject starPartical;
    private LogSystem logsys;
    [SerializeField]
    private GameObject hat;
    [SerializeField]
    private GameObject weapon;

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        cc = player.GetComponent<CharController>();
        logsys = player.GetComponent<LogSystem>();
        
        // default equipment
        AddItem("e02");
        AddItem("w02");

        // corona
        // AddItem("corona");
    }

    private void Update() {
        DisplayBag();
        if(!hat || !weapon) {
            hat = GameObject.FindGameObjectWithTag("hat");
            weapon = GameObject.FindGameObjectWithTag("weapon");
        }
    }
    // on collision method call this method, default pick up amount is 1
    public void AddItem(string id, int amount = 1) {
        // if item already exist
        if(items.ContainsKey(id)) {
            items[id] += amount; // update amount of this item
            logsys.DisplayLog("You received a new item");

        }
        else { // if it is a new item, create it
            items.Add(id, amount);
            logsys.DisplayLog("You received a new item");
        }
    }

    public void AddItemByName(string name, int amount = 1) {
        string id = "";
        switch(name) {
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
        }
        AddItem(id);
        }

    // todo: test this method
    public void LoseItem(string id, int amount = 1) {
        // 1. check if the item amount
        if(items[id] < amount) {
            //Debug.Log("<color=magenta> Can't find this item");
            logsys.DisplayLog("Can't find this item");
        }
        else { // at least have amount left
            // update the amount
            items[id] -= amount;
        }

        // 2. Check if the item is running out, if yes, delete it
        //    So there won't be a item in the bag has 0 or -1 left. 
        if(items[id] <= 0) {
            items.Remove(id);
        }
    }

    public void DisplayBag() {
        string display = "Bag:            ";
        foreach(string key in items.Keys) {
            int amount = items[key];
            display += key + " : " + amount + "            ";
        }
        Debug.Log(display);
    }

    public void UseAction(string id) {
        // use id to indicate which action to perform
        try {
            LoseItem(id);
            string currentHat = hat.GetComponent<Image>().sprite.name;
            string currentWeapon = weapon.GetComponent<Image>().sprite.name;

            switch(id) {
                case "0001":
                logsys.DisplayLog("hp++");
                cc.hp++;
                break;

                case "0002":
                logsys.DisplayLog("hp++  ep++");
                cc.hp++;
                cc.ep++;
                break;

                case "0003":
                cc.ep++;
                logsys.DisplayLog("ep++");
                break;

                case "0004":
                logsys.DisplayLog("hp++, tasty");
                cc.hp++;
                break;

                case "f01":
                cc.hp++;
                cc.ep++;
                logsys.DisplayLog("Delicious Watermelon");
                break;

                case "00010001":
                logsys.DisplayLog("What a tasty fried egg");
                break;

                case "00010002":
                cc.hp++;
                cc.ep++;
                logsys.DisplayLog("delicious Egg with Chicken");
                break;

                case "00030004":
                logsys.DisplayLog("this xingxing meat stew is so good");
                break;

                case "e01":
                logsys.DisplayLog("equip magic hat");
                // change character's hat
                hat.GetComponent<Image>().sprite = GameObject.Find("e01").GetComponent<SpriteRenderer>().sprite;
                // remove the new hat, add the old hat to bag.
                AddItemByName(currentHat);
                break;

                case "e02":
                logsys.DisplayLog("equip cowboy hat");
                hat.GetComponent<Image>().sprite = GameObject.Find("e02").GetComponent<SpriteRenderer>().sprite;
                AddItemByName(currentHat);
                break;

                case "w01":
                // change character's weapon
                logsys.DisplayLog("equip wood club");
                weapon.GetComponent<Image>().sprite = GameObject.Find("w01").GetComponent<SpriteRenderer>().sprite;
                // remove the new hat, add the old hat to bag.
                AddItemByName(currentWeapon);
                break;

                case "w02":
                logsys.DisplayLog("equip stone hammer");
                weapon.GetComponent<Image>().sprite = GameObject.Find("w02").GetComponent<SpriteRenderer>().sprite;
                AddItemByName(currentWeapon);
                break;

                case "corona":
                cc.hp++;
                cc.ep++;
                break;
            }
        }
        catch(KeyNotFoundException e) {
            Debug.Log(e);
            logsys.DisplayLog("<color=blue><size=25>You don't have this item</size></color>");
        }
    }

    public void Cook(string id) {
        try {
            // lose items first, add item after.
            LoseItem(id.Substring(1, 4)); // lose ingredient 1
            LoseItem(id.Substring(5, 4)); // lose ingredient 2
            AddItem(id.Substring(1, 8)); // get food 

            DisplayBag();
        }
        catch(KeyNotFoundException e) {
            Debug.Log(e);
            logsys.DisplayLog("<color=blue><size=25>You don't have this item</size></color>");

        }


        // todo exceptions 
    }
}
