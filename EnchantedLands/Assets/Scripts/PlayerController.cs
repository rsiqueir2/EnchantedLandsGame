using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool jump = false;
    private Animator anim;
    private bool noChao = false;
    private Transform groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        // Checando todos os Grounds
        groundCheck = gameObject.transform.Find("GroundCheck");

    }

    // Update a cada frame do jogo
    void Update()
    {

        //Se o botão Jump for acionado e o personagem estiver no chão ele vai pular
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && noChao)
        {

            jump = true;
            anim.SetTrigger("Pulou"); //Setando a trigger de pulo na animação

        }

    }
    //Baseado na fisica do jogo
    private void FixedUpdate()
    {

        float h = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Velocidade", Mathf.Abs(h));

        // Tratando a velocidade do personagem 
        rb.velocity = new Vector2(h * speed, rb.velocity.y);

        //Virar
        if (h > 0 && !facingRight)
        { // Se não estiver virado pra direita chama flip

            Flip();

        }
        else if (h < 0 && facingRight)

        {

            Flip();

        }

        //Pular
        if (jump)
        {

            rb.AddForce(new Vector2(0, jumpForce));
            jump = false;

        }
    }

    void Flip()
    {

        //Inversão
        facingRight = !facingRight;

        // Pega valor do Scale 
        Vector3 TheScale = transform.localScale;
        TheScale.x *= -1; //Manipulando X para o valor inverter 
        transform.localScale = TheScale;

    }
}
