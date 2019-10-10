using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cook : MonoBehaviour {
    [SerializeField]
    private BagManager bm;
    private GameObject player;
    private GameObject stove;
    public bool closeToStove;
    public List<string> recipes = new List<string>();
    public GameObject cookpanel;
    private LogSystem ls;

    // Use this for initialization
    void Start () {
        closeToStove = false;
        //cookpanel = GameObject.Find("cookPanel");
        player = GameObject.FindGameObjectWithTag("Player");
        ls = player.GetComponent<LogSystem>();
    }

    // Update is called once per frame
    void Update () {
        // stand beside stove and press up key
        if(closeToStove && Input.GetAxisRaw("Vertical") > 0) {
            cookpanel.SetActive(true);
            foreach(string key in bm.items.Keys) {
                if(key.StartsWith("1")){ // this is a recipe
                    recipes.Add(key);// store all recipes in list
                }
            }
        }

        if(!bm) {
            bm = player.GetComponentInChildren<BagManager>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            closeToStove = true;
            ls.DisplayLog("<color=red> Game Saved </color>");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            closeToStove = false;
            cookpanel.SetActive(false);
        }
    }

    public void CookRecipe(string id) {
        bm.Cook(id);
    }
}
