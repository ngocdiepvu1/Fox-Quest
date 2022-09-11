using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot1 : MonoBehaviour
{
    bool facingRight = true;
    public float speed = 2.0f;

    public GameObject gameOverScene;
    AudioSource dieSound;

    // Start is called before the first frame update
    void Start()
    {
        dieSound = GetComponent<AudioSource>();

        if (!facingRight)
            FlipFacing();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (facingRight)
            transform.Translate (Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate (-Vector2.right * speed * Time.deltaTime);
         
        if(transform.position.x >= 73.0f) {
            FlipFacing();
        }
         
        if(transform.position.x <= 67.0f) {
            FlipFacing();
        }
    }

    void FlipFacing()
    {
        facingRight = !facingRight;
        Vector3 charScale = transform.localScale;
        charScale.x *= -1.0f;
        transform.localScale = charScale;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            dieSound.Play();

            gameOverScene.SetActive(true);

        }
    }
}
