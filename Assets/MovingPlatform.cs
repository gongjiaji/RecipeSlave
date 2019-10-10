using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public GameObject smock;
    [SerializeField]
    private float time;
    private bool standing;

	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(standing) {
            IncreaseTime();
        }
        if(time > 2f) {
            Destroy(gameObject);
        }
	}

    private void OnCollisionStay2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")){
            Instantiate(smock,transform.position,transform.rotation);
            standing = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision) {
        ResetTime();
        standing = false;
    }

    private void IncreaseTime() {
        time+=Time.deltaTime;
    }

    private void ResetTime() {
        time = 0;
    }
}
