using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFireball2 : MonoBehaviour {

    public float speed;
    private GameObject player;

    // Use this for initialization
    void Start() {
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        StartCoroutine(DestroySelf());
    }

    // skill1 hit enemy 
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("enemy")) {
            // 1. destory the fireball
            Destroy(gameObject);
            // 2. deal damage to enemy
            collision.gameObject.GetComponent<EnemyController>().LoseHP(
                player.GetComponent<CharController>().skill2Attack);
        }
    }

    IEnumerator DestroySelf() {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
