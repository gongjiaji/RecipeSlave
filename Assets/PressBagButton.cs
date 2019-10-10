using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressBagButton : MonoBehaviour
{
    private BagManager bm;
    public GameObject itemPrefab;
    public GameObject bagIcon;
    private float bagIconX;
    private bool isBagOpen;
    private GameObject[] itemPrefabList;
    // Start is called before the first frame update
    void Start()
    {
        bagIconX = bagIcon.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(!bm) {
            bm = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<BagManager>();
        }
        itemPrefabList = GameObject.FindGameObjectsWithTag("ItemBoarder");

        if(!isBagOpen) {
            foreach(GameObject x in itemPrefabList) {
                Destroy(x);

            }
        }
    }


    // what happend when player press the button.
    public void OnButtonPressed() {
        isBagOpen = !isBagOpen;

        GameObject itemBoarder; // white empty square
        //float itemX = bagIconX;
        float itemX = 120;

        foreach(string key in bm.items.Keys) {
            GameObject sprite = GameObject.Find(key); // find the sprite game object. assign it to the prefab later
            // instantiate new item boarder, 100 px gap. replace the sprite with the correct one.

            itemBoarder = GameObject.Instantiate(itemPrefab);
            itemBoarder.transform.parent = bagIcon.transform;
            itemBoarder.transform.localScale = new Vector3(300, 300, 300);
            //itemBoarder.transform.position = new Vector2(itemX, 0);
            itemBoarder.transform.localPosition = new Vector2(itemX, 0);

            itemBoarder.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sprite.GetComponent<SpriteRenderer>().sprite;
            itemX += 120;
        }
    }
}