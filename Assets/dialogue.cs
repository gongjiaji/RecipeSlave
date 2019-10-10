using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogue : MonoBehaviour {
    public TextMeshProUGUI tmp;
    public string[] sentences;
    private int index; 
    private float speed; // npc talking speed
    public Button nextButton;
    public Button assignButton;
    //public Button finishButton;


    // Use this for initialization
    void Start () {
        speed = 0.002f;
        index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(tmp.text == sentences[index]) {
            nextButton.gameObject.SetActive(true);
        }
	}

    IEnumerator display() {
        foreach(char x in sentences[index].ToCharArray()) {
            tmp.text += x;
            yield return new WaitForSeconds(speed);

        }
    }

    public void NextLine() {
        nextButton.gameObject.SetActive(false);

        if(index < sentences.Length - 1) {
            index++;
            tmp.text = "";
            StartCoroutine(display());
        }
        else {
            tmp.text = "";
            nextButton.gameObject.SetActive(false);
            assignButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            assignButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            index = 0;
        }
        assignButton.gameObject.SetActive(false);
    }

    public void FirstLine() {
        StartCoroutine(display());
        assignButton.gameObject.SetActive(false);
    }
}
