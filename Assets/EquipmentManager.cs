using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    private GameObject player;
    public Button hat;
    public Button weapon;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.Find("hat").gameObject.GetComponent<SpriteRenderer>().sprite
            = hat.GetComponent<Image>().sprite;
        player.transform.Find("rotatePoint").gameObject.transform.Find("weapon").GetComponent<SpriteRenderer>().sprite= weapon.GetComponent<Image>().sprite;
    }
}
