using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;

    public float intervaloDeAtaque;
    private float proximoAtaque;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tratando os ataques
        if (Input.GetButtonDown("Fire1") && Time.time > proximoAtaque) {

            Atacando();
        }

    }
    // Função de ataque mundando animação + tempo atual para o proximo ataque
    void Atacando() {

        anim.SetTrigger("Atacando");

        proximoAtaque = Time.time + intervaloDeAtaque;

    }
}
