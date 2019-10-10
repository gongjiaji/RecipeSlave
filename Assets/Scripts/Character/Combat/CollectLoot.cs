using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLoot : MonoBehaviour {
    public BagManager im; //item manager

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "food") {
            string itemId = collision.gameObject.GetComponent<Item>().id;
            // add to bag
            im.AddItem(itemId); // add 1 item to bag
            im.DisplayBag();
            // destory it for current phase 
            Destroy(collision.gameObject);
        }
    }
}
