using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skunk : MonoBehaviour
{
    public GameObject skunkText;
    public GameObject skunkText2;
    public MoleCounter moleCounter;

    // Start is called before the first frame update
    void Start()
    {
        moleCounter = GameObject.Find("MoleCounter").GetComponent<MoleCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
        
            if (moleCounter.moleCount == 3) {
                skunkText2.SetActive(true);
            }
            else {
                skunkText.SetActive(true);
            };

        }
    }
}
