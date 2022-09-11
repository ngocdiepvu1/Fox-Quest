using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterDrop : MonoBehaviour
{
    GameObject player;
    Animator anim;
    public AudioClip waterdrop;
    AnimatorStateInfo currentState;
    public float vicinity = 10.0f;
    public float timerLength = 5.0f;
    float timerStart;
    bool waterStateVisited = false;

    // Awake is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        player= GameObject.FindGameObjectWithTag("Player");
        timerStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentState = anim.GetCurrentAnimatorStateInfo(0);

        if (currentState.fullPathHash == Animator.StringToHash("Base Layer.WaterIdle") && Time.time > timerStart + timerLength) {
            anim.SetBool("blast", true);
        }
        if (anim.IsInTransition(0)) {
            if (currentState.fullPathHash == Animator.StringToHash("Base Layer.water drop") && !waterStateVisited 
            && (Mathf.Abs(transform.position.x - player.transform.position.x) < vicinity)) 
            {
                StartCoroutine("PerformExplosion");
            }

            if (currentState.fullPathHash == Animator.StringToHash("Base Layer.blast") && waterStateVisited)
            {
                StartCoroutine("PerformExplosion");
            }

        } 
    }
    IEnumerator PerformExplosion()
    {
        Vector3 tf = transform.position;
        tf.z = -2;
        gameObject.transform.position = tf;

        GetComponent<AudioSource>().PlayOneShot(waterdrop,1.0f);
        waterStateVisited = true;

        //yield return new WaitUntil
        yield return new WaitForSeconds(0.3f);

        //Destroy(player.gameObject, 0.5f);
        foreach(Transform child in player.gameObject.transform)
            child.gameObject.SetActive(false);

        Destroy(gameObject);
        //SceneManager.LoadScene(0);
        
    }
}
