using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOutLine : MonoBehaviour {
    public Animator animator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            animator.SetBool("isClose", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            animator.SetBool("isClose", false);
        }
    }
}
