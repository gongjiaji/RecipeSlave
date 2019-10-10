using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eat : MonoBehaviour {
    private BagManager bm;

    // Use this for initialization
    void Start () {
        bm = GameObject.Find("bag").GetComponent<BagManager>();
    }

    // Update is called once per frame
    void Update () {

    }

    public void Eat(string id) {
        bm.UseAction(id);
    }
}
