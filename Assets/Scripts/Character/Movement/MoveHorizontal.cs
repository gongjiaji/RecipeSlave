using UnityEngine;

public class MoveHorizontal : MonoBehaviour {
    public float speed = .1f;
    private Animator animator;

    // Use this for initialization
    private void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update() {
        if(!GetComponent<CharController>().isDead) {
            // ---> 
            if(Input.GetAxisRaw("Horizontal") > 0) {
                // move right 
                Vector3 temp = transform.position;
                temp.x += speed;
                transform.position = temp;

                // turn face to right 
                Quaternion temp1 = transform.rotation;
                temp1.y = 0;
                transform.rotation = temp1;

                // running animation
                animator.SetBool("run", true);
            }
            // <---
            else if(Input.GetAxisRaw("Horizontal") < 0) {
                // move left 
                Vector3 temp = transform.position;
                temp.x -= speed;
                transform.position = temp;

                // turn face to left 
                Quaternion temp1 = transform.rotation;
                temp1.y = -180;
                transform.rotation = temp1;

                // running animation
                animator.SetBool("run", true);
            }
            // standstill
            else {
                animator.SetBool("run", false);
            }

        }
    }
}
