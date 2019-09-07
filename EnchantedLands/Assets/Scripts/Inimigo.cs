using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    bool facingRigth = false;
    bool noChao = false;
    Transform groundCheck;
    public float jumpForce = 700;

    //Sons
    AudioSource audioS;


    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        //Check do chão
        groundCheck = transform.Find("InimigoGroundCheck");
        audioS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //Verifica se está no chão, se ele estiver troca a velocidade
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (!noChao)
            speed *= -1;

    }
    private void FixedUpdate()
    {

        // Andar sozinho para os lados, quando for cair inverte a velocidade
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (speed > 0 && !facingRigth)
        {

            Flip();

        }

        else if (speed < 0 && facingRigth)
        {

            Flip();

        }
    }

    void Flip() {

        facingRigth = !facingRigth;
        //Usando um vetor de 3 posições para mudar a escala
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    // Para desativar as BoxColliders, se desativar as duas ok

        
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
