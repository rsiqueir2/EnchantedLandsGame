using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    bool vivo = true;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        anim = gameObject.GetComponent<Animator>();

        GameManager.gm.AtualizaHud();

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void PerdeVida()
    {
        if (vivo)
        {

            vivo = false;
            anim.SetTrigger("Morrendo");
            GameManager.gm.SetVidas(-1);
            gameObject.GetComponent<PlayerAttack>().enabled = false;
            gameObject.GetComponent<PlayerController>().enabled = false;


        }

    }


    public void Reset()
    {
        if (GameManager.gm.GetVidas() >= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        else
        {
            SceneManager.LoadScene(4);
        }
    }
}
