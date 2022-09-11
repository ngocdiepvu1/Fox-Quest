using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterSky : MonoBehaviour
{
    private GameObject instance;
    public GameObject gameOverScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        instance = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Spawner>().instance;
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            gameOverScene.SetActive(true);
        } 
        else if (collision.gameObject.tag == "Ground")
        {
            Destroy(instance,0.05f);
        }

    }
}
