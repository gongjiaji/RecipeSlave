using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// find player, set player to the location of enter point.
// so whenever player load in a new scene, it will be at the right place.

public class SetPlayerEnterPoint : MonoBehaviour {
    private GameObject player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = gameObject.transform.position;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
