using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToHomeCamera : MonoBehaviour
{
    public Camera homeCam;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > 7.0f) {
            homeCam.depth = 1;
        }
        else {
            homeCam.depth = -2;
        }
    }
}
