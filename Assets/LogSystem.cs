using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject tmpro;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        tmpro = GameObject.FindGameObjectWithTag("logText");
        text = tmpro.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!tmpro || !text) {
            tmpro = GameObject.FindGameObjectWithTag("logText");
            text = tmpro.GetComponent<TextMeshProUGUI>();
            text.text = "";
        }
    }

    public void DisplayLog(string msg) {
        text.text = msg;
        StartCoroutine(RemoveText());
    }

    IEnumerator RemoveText() {
        yield return new WaitForSeconds(3f);
        text.text = "";
    }
}
