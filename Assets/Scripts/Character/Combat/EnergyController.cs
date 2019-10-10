using UnityEngine;

public class EnergyController : MonoBehaviour {
    private GameObject[] energies; // store energy containers
    private int ep;

    // Use this for initialization
    private void Start() {
        energies = GameObject.FindGameObjectsWithTag("ep");
    }

    // Update is called once per frame
    private void Update() {
        ep = GetComponent<CharController>().ep;
        for(int i = 0; i < energies.Length; i++) {
            if(ep <= i) {
                energies[i].SetActive(false);
            }
        }
    }
}
