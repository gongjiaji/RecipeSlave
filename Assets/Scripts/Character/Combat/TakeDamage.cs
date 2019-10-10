using System.Collections;
using UnityEngine;

public class TakeDamage : MonoBehaviour {
    private float time; //  control flash speed 
    private float aValue; // char sprite alpha value, switch between 0.2 and 1.0 to implement flash
    private float totalTime; // flash duration
    private CharController charController;
    public bool invinciable; // true: invinciable, flash & take no damage 


    // Use this for initialization
    private void Start() {
        charController = GetComponent<CharController>();
        charController.isDead = false;
        invinciable = false;
        time = 0f;
    }

    // Update is called once per frame
    private void Update() {
        // prevent unlimited loop animation 
        // isdead will be true when die animation play finished 
        if(charController.isDead) {
            GetComponent<Animator>().SetBool("die", false);
        }

        if(invinciable) {
            Invinciable(2);
        }
    }

    // invinciable for n seconds 
    public void Invinciable(float n) {
        FlashChar(n);
    }

    // whenever lose Hp, enemy call this function, n is enemy's attack 
    public void LoseHp(int n) {
        // if char is invinciable, do not take any damage
        if(!invinciable) {
            charController.hp -= n;
            invinciable = true;
            GetComponent<Animator>().SetTrigger("hurt");
        }
    }

    // flash char by changing alpha value
    private void FlashChar(float n) {
        bool state = false;
        time += Time.deltaTime * 5; // the value control flash speed 
        totalTime += Time.deltaTime; // total flash time 

        if(totalTime < n) {
            // start flash 
            if(time > 0.2f) {
                state = true;
                time = 0;
            }
            // decrease the alpha value gradually.
            // reset to normal and run again. 
            if(state) {
                aValue -= 0.1f;

                state = false;
                if(aValue <= 0) {
                    aValue = 1f;

                }
            }
            // assign this color to char 
            gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, aValue);
        }
        else // flash over 
        {
            // reset to normal, ready for next time flash 
            gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);
            invinciable = false;
            totalTime = 0;
        }
    }
}
