using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour {
    public int hp;
    public int ep;
    public float meleeAttack;
    public float rangeAttack;
    public float skill1Attack;
    public float skill2Attack;
    public float ultiSkillAttack; // per enery point
    public bool isDead;
    public GameObject[] bag;
    public GameObject lastStove; // last visit stove , the position 
    private Animator animator;
    public GameObject enterPoint;
    public List<Requests> requests; // the requests on going

    // singleton
    public bool flag = true;
    public bool DontCreateNewWhenBackToThisScene = true;
    public static CharController Instance = null;
    void Awake() {
        if(Instance != null) {
            GameObject.Destroy(this.gameObject);
            return;
        }
        Instance = this;
        if(this.flag)
            GameObject.DontDestroyOnLoad(this);
    }


    private void Start() {

        animator = GetComponent<Animator>();
        requests = new List<Requests>();
    }
    // Update is called once per frame
    private void Update() {
        if(!enterPoint) {
            enterPoint = GameObject.Find("EnterPoint");
            lastStove = enterPoint;
        }

        CheckDeath();
        CheckifFullHpEp();
    }

    // other script call this method. 
    public void LoseEp(int cost) {
        ep -= cost;
    }

    private void CheckifFullHpEp() {
        if(hp > 5) {
            hp = 5;
        }
        if(ep > 5) {
            ep = 5;
        }
    }

    // always checking if player is dead
    private void CheckDeath() {
        if(hp <= 0 && isDead == false) { // from alive to die 
            animator.SetBool("die", true);
            animator.SetBool("die_played", true);
            // execute respawn action
            StartCoroutine(DelayTransform(2));
        }
        else {
            animator.SetBool("die", false);
        }
    }

    // call this function after death, delay 2 seconds, play die animation 
    public IEnumerator DelayTransform(float delaySeconds) {
        animator.SetBool("die_played", false);

        yield return new WaitForSeconds(delaySeconds);
        // what happend after death?
        // 1. set player position next to stove. 
        transform.position = lastStove.transform.position+new Vector3(0,0.3f,0);
        // 2. reset hp to full 
        hp = 5;
        // 3. player no longer "isDead" state
        isDead = false;
    }

    public void GoToLastStove() {
        Debug.Log("called ");
        Debug.Log("called finish");
    }

    // get new request from npc, add it to list.
    public void AddRequest(Requests quest) {
        requests.Add(quest);
        Debug.Log("a quest added." + quest.id + quest.name + quest.description + quest.rewards.Length);
    }

}
