using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamFollowPlayer : MonoBehaviour {
    private GameObject player;
    private CinemachineVirtualCamera cam;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GetComponent<CinemachineVirtualCamera>();
        cam.Follow = player.transform;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
