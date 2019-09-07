using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

//Para o personagem seguir o inimigo
[RequireComponent(typeof(NavMeshAgent))]
public class Inimigo3 : MonoBehaviour
{
    public float speed;
    private Transform t;
    Rigidbody2D rb;
    private bool facingRight = true;
    private Animator anim;
    AudioSource audioS;
    public float jumpForce = 200;

    // Start is called before the first frame update
    void Start()
    {
        t = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        audioS = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, t.position, speed * Time.deltaTime);

        // Tratando a velocidade do inimigo
        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        //Virar
        if (h > 0 && facingRight)
        { // Se não estiver virado pra direita chama flip para virar

            Flip();

        }
        else if (h < 0 && !facingRight)

        {

            Flip();

        }

        void Flip()
        {

            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    // Desativa os Boxcollider2D, os dois em uma só 

    /* Primeiro Box sem Trigger é o box de morrer

     Segundo box com Trigger é o de matar
     */
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
    //Se bate no inimigo perde 1 vida 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioS.Play();
            other.gameObject.GetComponent<PlayerLife>().PerdeVida();


        }
    }

}
