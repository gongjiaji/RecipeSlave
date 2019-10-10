using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoor : MonoBehaviour {
    public GameObject player;
    public GameObject outPoint;
    public Vector3 offset;
    private float cd;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        cd = 0.5f;
    }

    private void Update() {
        cd -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        // if player is stanidng in front of door
        if(collision.CompareTag("Player")) {
            // if player press up arrow, open the door
            if(Input.GetAxisRaw("Vertical") > 0 && cd <0) {
                OpenDoor();
                cd = 1.5f;
            }
        }
    }

    public void OpenDoor() {
        player.transform.position = outPoint.transform.position + offset;
    }
}
