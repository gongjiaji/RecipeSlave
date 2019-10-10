using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : MonoBehaviour {
    public GameObject player;
    public float cd;
    [SerializeField]
    private float timer;
    public GameObject fireball;
    private GameObject ob;
    // Use this for initialization
    void Start () {
        timer = -1;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.N)) {
            // if player has enough ep to cast the skill
            // and cd is ready
            if(player.GetComponent<CharController>().ep >= 2 && timer<0) {
                ob = Instantiate(fireball, transform.position, transform.rotation);
                // consume 2 ep
                player.GetComponent<CharController>().ep -= 2;
                timer = cd;
            }

        }
    }
}
