using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAnimation : MonoBehaviour {
    public FadeAnimation fa;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        fa.enabled = true;
	}
}
