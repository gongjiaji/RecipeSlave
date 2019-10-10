using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour {
    public FadeAnimation fa;
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            fa.trigger = true;
        }
    }
}
