using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public float forcaHorizontal = 15;
    public float forcaVertical = 10;
    public float tempoDeDestruicao = 1;


    float forcaHorizontalPadrao;
    // Start is called before the first frame update
    void Start()
    {

        forcaHorizontalPadrao = forcaHorizontal;

    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Inimigo"))

        {         // Desativar o Script inimigo
            
            //other.gameObject.GetComponent<Inimigo>().enabled = false;
          //  other.gameObject.GetComponent<Inimigo2>().enabled = false;
          // other.gameObject.GetComponent<Inimigo3>().enabled = false;

            //Pra cada BoxCollider ele vai executar o loop
            BoxCollider2D[] boxes = other.gameObject.GetComponents<BoxCollider2D>();

            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;  //Desativando o Boxcollider2D
            }
            /* Verifica se o inimigo esta a direita ou esquerda
           Se a posição do X do inimigo for menor que o nosso valor inverte */

            if (other.transform.position.x < transform.position.x)
                forcaHorizontal *= -1;

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaHorizontal, forcaVertical), ForceMode2D.Impulse);

            Destroy(other.gameObject, tempoDeDestruicao);

            forcaHorizontal = forcaHorizontalPadrao;
        }
    }
}
