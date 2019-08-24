using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    private int vidas = 3;


    // Inicia antes do objeto em cena
    void Aweke()

    {

        if (gm == null)
        {
            // Não destruir o objeto ao passar a cena
            gm = this;
            DontDestroyOnLoad(gameObject);
        }

        // Se ja existir destrói
        else
        {
            Destroy(gameObject);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVidas(int vida)
    {
        vida += vida;

    }

    public int GetVidas()
    {
        return vidas;

    }

}
