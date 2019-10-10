using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueBaseImgManager : MonoBehaviour
{
    public GameObject image;
    private bool hasText;
    
    // Start is called before the first frame update
    void Start()
    {
        hasText = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<TextMeshProUGUI>().text == "") {
            hasText = false;
        }
        else {
            hasText = true;
        }
        image.SetActive(hasText);
    }
}
