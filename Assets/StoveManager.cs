using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveManager : MonoBehaviour {
    private CharController cc;
    public Cook cook;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision) {
        // when player move in the range of stove
        if(collision.CompareTag("stove")) {
            cc.lastStove = collision.gameObject;
            cook.closeToStove = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("stove")) {
            cook.closeToStove = false;
        }
    }
}
