using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFruit : MonoBehaviour {
    public bool isCollectable;
    public string fruitId;
    private BagManager bm;
    public float regenTime; //5min
    [SerializeField]
    private float cd;
    private bool inRange;
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        isCollectable = true;
        cd = regenTime;
        bm = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<BagManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!isCollectable) {
            cd -= Time.deltaTime;
            anim.SetBool("isCollectable", false);
        }
        else {
            anim.SetBool("isCollectable", true);
        }

        if(cd < 0) {
            isCollectable = true;
            cd = regenTime;
        }


        if(inRange && isCollectable) {
            if(Input.GetKeyDown(KeyCode.W)) {
                bm.AddItem(fruitId);
                isCollectable = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            inRange = false;
        }
    }
}
