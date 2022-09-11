using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinCounter coinCounter;
    AudioSource coinSound;

    // Start is called before the first frame update
    void Start()
    {
        coinCounter = GameObject.Find("CoinCounter").GetComponent<CoinCounter>();
        coinSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            
            coinSound.Play();

            coinCounter.coinCount++;
            gameObject.SetActive(false);
        }
    }
}
