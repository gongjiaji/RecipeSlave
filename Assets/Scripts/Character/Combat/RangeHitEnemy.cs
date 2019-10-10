using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeHitEnemy : MonoBehaviour {
    public static bool hit = false;
    GameObject enemy;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("enemy")) {
            hit = true;
            enemy = collision.gameObject;
            enemy.GetComponent<EnemyController>().LoseHP(player.GetComponent<CharController>().rangeAttack);
        }
    }
}
