using UnityEngine;

public class Patrol : MonoBehaviour {
    private float speed;
    public float rageSpeed;
    public float normalSpeed;
    private bool faceRight;
    public float detectionDepth;
    public Transform GroundChecker;
    public GameObject PlayerChecker;
    private Animator ani;
    public GameObject flame;

    // Use this for initialization
    private void Start() {
        ani = GetComponent<Animator>();
        speed = normalSpeed;
    }

    // Update is called once per frame
    private void Update() {
        // simply move in one direction. not using rigidbody
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        // raycast downward, detect ground. if empty return false 
        RaycastHit2D ground = Physics2D.Raycast(GroundChecker.position, Vector2.down, detectionDepth);

        // about to fall 
        if(!ground) {
            if(faceRight) {
                transform.eulerAngles = new Vector3(0, -180, 0);
                faceRight = false;
            }
            else {
                faceRight = true;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    // if the player checker detects the player
    private void OnTriggerStay2D(Collider2D collision) {
        string enemyName = gameObject.name;
        // player is in the range
        if(collision.CompareTag("Player")) {
            switch(enemyName){
                case "Elite_XingXing":
                //1. move fast
                speed = rageSpeed;
                break;

                case "Boss":
                speed = rageSpeed;
                flame.SetActive(true);
                break;
            }
        }
    }

    // if player leaving the checker
    private void OnTriggerExit2D(Collider2D collision) {
        string enemyName = gameObject.name;
        // player is out of range
        if(collision.CompareTag("Player")) {
            switch(enemyName) {
                case "Elite_XingXing":
                //1. move fast
                speed = normalSpeed;
                break;

                case "Boss":
                speed = rageSpeed;
                flame.SetActive(false);
                break;
            }
        }
    }
}

