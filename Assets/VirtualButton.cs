
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButton : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject vbButton;
    public Animator animator;
    public GameObject text;
    private BagManager bm;
    public string itemName;

    // Start is called before the first frame update
    void Start() {
        vbButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }

    // Update is called once per frame
    void Update() {
        if(!bm) {
            bm = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<BagManager>();
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        //animator.SetBool("pressed",true);
        text.SetActive(false);
        bm.AddItem(itemName);
        Debug.Log("ON");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        //animator.SetBool("pressed",false);
        Debug.Log("OFF");
    }
}