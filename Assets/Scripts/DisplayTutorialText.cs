using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTutorialText : MonoBehaviour {
    private Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            // if the player get close to the point
            // display the tutorial text
            text.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            // if the player get out of the range
            // destroy the totorial text forever
            // only display one time
            Destroy(gameObject);
        }
    }
}
