using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestManager : MonoBehaviour {
    public Button requestButton;
    public Button requestFinishButton;

    public dialogue dialogue;
    public string[] sentences;

    public CharController cc;
    private GameObject player;
    public BagManager bm;

    public bool hasRequest;
    public string[] requestContent = new string[3]; // holding the details of request
    public string[] rewards; // the item id
    public Dictionary<string, int> questGoal; // what's the requirement of the request
    public string[] questGoalIdList;
    public int[] questGoalAmountList;
    public Requests request;
    public bool isRequestFinished;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        cc = player.GetComponent<CharController>();
        bm = player.GetComponentInChildren<BagManager>();
    }

    // Use this for initialization
    private void Start() {
        hasRequest = true;
        //set request goal
        questGoal = new Dictionary<string, int>();
        if(questGoalAmountList.Length == questGoalAmountList.Length) {
            for(int i = 0; i < questGoalAmountList.Length; i++) {
                questGoal.Add(questGoalIdList[i], questGoalAmountList[i]);
            }
        }
    }

    // Update is called once per frame
    private void Update() {
        requestButton.gameObject.SetActive(hasRequest);
        if(!isRequestFinished) {
            CheckRequest();

        }
    }

    public void OnRequestButtonClicked() {
        dialogue.sentences = sentences;
        hasRequest = false;
        CreateRequest();
        cc.AddRequest(request);
        isRequestFinished = false;
    }

    public void OnRequestFinishedButtonClicked() {
        // give items to NPC
        foreach(string id in questGoal.Keys) {
            bm.LoseItem(id, questGoal[id]);
            Debug.Log("Finish quest, you lost " + id + questGoal[id]);
        }
        requestFinishButton.gameObject.SetActive(false);

        // give reward to player
        foreach(string id in rewards) {
            bm.AddItem(id);
            Debug.Log("You get the reward" + id);
        }
    }

    // create a reqeust type object, later char controller class could access the data.
    public void CreateRequest() {
        request = new Requests(requestContent, rewards);

    }

    private void CheckRequest() {
        bool flag = true; // check request status.
        foreach(string id in questGoal.Keys) {
            if(bm.items.ContainsKey(id)) {
                // check only, not lose item until player talk to npc
                if(bm.items[id] >= questGoal[id]) {
                    Debug.Log("Checked " + id + " total has " + bm.items[id]);
                }
                else {
                    flag = false;
                }
            }
            else {
                flag = false;
            }
        }
        isRequestFinished = flag;

        if(isRequestFinished) {
            requestFinishButton.gameObject.SetActive(true);
            hasRequest = false;
        }
    }

}
