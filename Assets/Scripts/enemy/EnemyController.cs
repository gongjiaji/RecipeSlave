using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float hp;
    public int attack;
    public bool isDead;
    public GameObject[] loots;
    private GameObject player;
    public Vector2 dropRate;
    public Vector3 lootOffset;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if(isDead) {
            Destroy(gameObject);
            DropLoot();
        }
    }

    private void DropLoot() {
        // todo
        int a = Random.Range(0, 100); // no.0 ~ no.99 
        int i = -1;
        if(a < dropRate.x) {
            i = 0;
        }else if (a < dropRate.y) {
            i = 1;
        }
        else {
            i = 2;
        }
        StartCoroutine(DelayDropLoot());
        Instantiate(loots[i], transform.position, transform.rotation);
    }

    // other script call this method. 
    public void LoseHP(float damage) {
        hp -= damage;
        if(hp <= 0) {
            isDead = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            player.GetComponent<TakeDamage>().LoseHp(attack);
        }
    }

    private IEnumerator DelayDropLoot() {
        yield return new WaitForSeconds(0.5f);
    }
}
