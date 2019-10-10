using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour {
    private CharController cc;
    // Start is called before the first frame update
    void Start() {
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharController>();
    }

    // Update is called once per frame
    void Update() {
        string sprite = GetComponent<Image>().sprite.name;
        switch(sprite) {
            case "woodClub":
            cc.meleeAttack = 1;
            break;

            case "Hammer":
            cc.meleeAttack = 2;
            break;
        }
    }
}
