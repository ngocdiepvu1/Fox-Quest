using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBox : MonoBehaviour
{
    public GameObject gameOverScene;
    AudioSource dieSound;

    void Start() {
        dieSound = GetComponent<AudioSource>();
        
        //gameOverScene = GameObject.FindGameObjectWithTag("Finish");
    
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            dieSound.Play();

            gameOverScene.SetActive(true);

        }
    }
}