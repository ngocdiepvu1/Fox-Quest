using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject character;
    Vector3 offset;
    AudioSource bgmusic;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position;
        bgmusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        offset.x = character.transform.position.x;
        transform.position = offset;
        
        if (Input.GetKeyDown("m")) 
            if (bgmusic.isPlaying)
                bgmusic.Pause();
            else 
                bgmusic.Play();
    }
}
