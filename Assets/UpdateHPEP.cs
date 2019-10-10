using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHPEP : MonoBehaviour {
    private GameObject player;
    public Scrollbar hpBar;
    public Scrollbar epBar;
    private CharController cc;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        cc = player.GetComponent<CharController>();
	}
	
	// Update is called once per frame
	void Update () {
        hpBar.size = cc.hp/5f;
        epBar.size = cc.ep/5f;
    }
}
