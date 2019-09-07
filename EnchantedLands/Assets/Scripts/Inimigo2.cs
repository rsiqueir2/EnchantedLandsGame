using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo2 : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    public float jumpForce = 700;
    AudioSource audioS;


    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        audioS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
   
    // Para desativar as BoxColliders, se desativar as duas ok, 
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Ataque"))

        {

            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes)
            {

                box.enabled = false;

            }

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));

            speed = 0;
            transform.Rotate(new Vector3(0, 0, -180));
            Destroy(gameObject, 3);


        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioS.Play();
            other.gameObject.GetComponent<PlayerLife>().PerdeVida();


        }
    }

}
