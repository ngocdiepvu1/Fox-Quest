using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public MoleCounter moleCounter;
    AudioSource moleSound;

    // Start is called before the first frame update
    void Start()
    {
        moleCounter = GameObject.Find("MoleCounter").GetComponent<MoleCounter>();
        moleSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            
            moleSound.Play();

            moleCounter.moleCount++;

            gameObject.SetActive(false);
        }
    }
}
