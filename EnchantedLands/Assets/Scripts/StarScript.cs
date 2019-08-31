using UnityEngine;
using System.Collections;

public class StarScript : MonoBehaviour
{

    Animator anim;
    CircleCollider2D col;
    

    AudioSource audioS;
    // Use this for initialization
    void Start()
    {

        anim = gameObject.GetComponent<Animator>();
        col = gameObject.GetComponent<CircleCollider2D>();
       audioS = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {

        // Se colidir 
        if (other.gameObject.CompareTag("Player"))
        {
            audioS.Play();
            GameManager.gm.SetStars(1);
            col.enabled = false;
            anim.SetTrigger("Coletando");

            //Destuir a estrelinha
            Destroy(gameObject, 0.483f);
        }
    }
}
