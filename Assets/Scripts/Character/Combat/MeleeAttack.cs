using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {
    public float cd;
    public float timer;//  the cool down between 2 attacks
    public GameObject rotatePoint;
    private GameObject player;
    public float pushDistance;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if(timer <= 0) {
            // can attack
            if(Input.GetKeyDown(KeyCode.J)) {
                player.GetComponent<Animator>().SetTrigger("attack");
                timer = cd; // reset cd 
            }

            
        }
        else {
            // can not attack, decrease cd
            timer -= Time.deltaTime;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        // when the weapon hit the enemy
        if(collision.gameObject.CompareTag("enemy")) {
            // enemy lose hp
            collision.GetComponent<EnemyController>().LoseHP(
                player.GetComponent<CharController>().meleeAttack);

            // enemy back off a bit
            // if hitting from left, enemy go right 
            Vector3 temp = collision.transform.position;
            if(transform.position.x < collision.transform.position.x) {
                temp.x += pushDistance;
            }
            else {// hitting from right, enmey go left 
                temp.x -= pushDistance;
            }
            collision.transform.position = temp;

            // player get 1 energy point
            player.GetComponent<CharController>().ep++;
        }
    }
}
