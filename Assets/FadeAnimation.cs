using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FadeAnimation : MonoBehaviour {
    //public GameObject ob;
    public bool trigger;
    public Animator ani;
    public int sceneId;

    private void Awake() {

    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if(trigger) {
            ani.SetTrigger("fadeOut");
        }
	}

    // controlled in animation.
    public void FadeComplete() {
        SceneManager.LoadScene(sceneId);

    }
}
