using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {
    // singleton
    public bool flag = true;
    public bool DontCreateNewWhenBackToThisScene = true;
    public static NPCController Instance = null;
    void Awake() {
        if(Instance != null) {
            GameObject.Destroy(this.gameObject);
            return;
        }
        Instance = this;
        if(this.flag)
            GameObject.DontDestroyOnLoad(this);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
