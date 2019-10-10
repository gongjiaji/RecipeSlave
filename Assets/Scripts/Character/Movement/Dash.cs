using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour {
    // speed and time
    [Range(0, 100)]
    public float dashSpeed;
    [Range(0, 1)]
    public float dashTime;
    private float timer; // compare with dash time. stop dash then 
    [Range(0, 5)]
    public float cd;
    [SerializeField]
    private bool canDash;
    [SerializeField]
    private bool isDashing;
    private Rigidbody2D rb;
    private Animator ani;
    //    private GameObject partical;

    // Use this for initialization
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        dashSpeed = 40f;
        dashTime = 0.15f;
        timer = 0;
        cd = 0f;
        ani = GetComponent<Animator>();
        //        partical = GameObject.FindGameObjectWithTag("dashPartical");
        //      partical.SetActive(false);
    }

    // Update is called once per frame
    private void Update() {
        cd -= Time.deltaTime; // reduce cd, even lower then 0. dashing function set cd to 2

        // detect dash behaviour, check cd, check ep
        if(Input.GetKeyDown(KeyCode.F)) {
            if(cd <= 0 && GetComponent<CharController>().ep >0) {
                canDash = true;
                GetComponent<CharController>().LoseEp(1);
            }
            else {
                canDash = false;
            }
        }

        if(canDash) {
            if(Input.GetAxisRaw("Horizontal") > 0) { // right dash 
                Dashing(Vector2.right);
            }
            else if(Input.GetAxisRaw("Horizontal") < 0) { // left dash
                Dashing(Vector2.left);
            }
        }
        else {
            timer = 0;
        }

        // not affect by physics while dashing
        // could put inside Dashing() function. 
        // take it out for easier understanding
        if(isDashing) {
            rb.bodyType = RigidbodyType2D.Kinematic;
            GetComponent<Collider2D>().enabled = false;
            ani.SetTrigger("dash");
            //            partical.SetActive(true);
        }
    }

    // what happend while dashing
    public void Dashing(Vector2 direction) {
        isDashing = true;
        rb.velocity = direction * dashSpeed;
        timer += Time.deltaTime;
        // what happend after dashing finished 
        if(timer >= dashTime) {
            canDash = false;
            rb.velocity = Vector2.zero;
            isDashing = false;
            cd = 2; // *********** set cd here **************
            GetComponent<Collider2D>().enabled = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(StopPartical(cd));
        }
    }

    // after cd seconds stop partical system. 
    // so player see particals disappear means cd is reset
    private IEnumerator StopPartical(float time) {
        yield return new WaitForSeconds(time);
        //        partical.SetActive(false);
    }
}

