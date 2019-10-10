using System.Collections;
using UnityEngine;

public class RangeAttack : MonoBehaviour {
    public Transform shootingPoint;
    public GameObject bullet;
    public float speed; // the bullet speed
    public float time; // how long the bullet exist
    public float cd; // the cooldown of firing 
    private bool isfire = false;

    // Use this for initialization
    private void Start() {
        bullet.SetActive(false);
        cd = 0;
    }

    // Update is called once per frame
    private void Update() {
        // if shoot

        if(Input.GetKeyDown(KeyCode.G)) {
            if(GetComponent<CharController>().ep > 0 && cd <=0) {
                bullet.SetActive(true);
                isfire = true;
                GetComponent<CharController>().ep--;
                cd = 2;
                GetComponent<Animator>().SetTrigger("throw");
            }
        }
        if(isfire) {
            Fire();
        }
        cd -= Time.deltaTime;
    }

    private void Fire() {
        bullet.transform.Translate(Vector2.right * speed * Time.deltaTime);
        if(RangeHitEnemy.hit) {
            bullet.SetActive(false);
            bullet.transform.position = shootingPoint.transform.position;
            isfire = false;
            RangeHitEnemy.hit = false;
        }
        else {
            StartCoroutine(DestoryBullet());
        }
    }

    public IEnumerator DestoryBullet() {
        yield return new WaitForSeconds(time);
        bullet.SetActive(false);
        bullet.transform.position = shootingPoint.transform.position;
        isfire = false;
    }
}
