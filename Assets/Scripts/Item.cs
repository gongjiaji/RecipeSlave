using UnityEngine;

public class Item : MonoBehaviour {
    public string itemName;
    public int rare;
    public string id;
    public string describtion;
    public string describtion2;
    public string describtion3;
    public string describtion4;

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("ground")) {
            // item drop to the ground, and stop moving
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
