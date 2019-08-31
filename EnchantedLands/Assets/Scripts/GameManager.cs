﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;

    private int vidas = 3;
    private int stars = 0;

    //Use this for initialization
    void Awake()
    {

        if (gm == null)
        {
            gm = this;
          //  DontDestroyOnLoad(gameObject);
        }

        else
            Destroy(gameObject);

    }

    void Start()
    {
        AtualizaHud();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetVidas(int vida)
    {
        vidas += vida;
        if (vidas >= 0)
            AtualizaHud();
    }

    public int GetVidas()
    {
        return vidas;
    }

    public void SetStars(int star)
    {

        //Ganha vida ao chegar em 50
        stars += star;
        if (stars >= 10)
        {
            stars = 0;
            vidas += 1;
        }

        AtualizaHud();
    }

    //Atualizar os valores, sempre que chamar setvidas
    public void AtualizaHud()
    {
        GameObject.Find("VidasText").GetComponent<Text>().text = vidas.ToString();
        GameObject.Find("StarText").GetComponent<Text>().text = stars.ToString();
    }

    //Carregamento da fase
    void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
           vidas = 3;
           stars = 0;
        }
    }


}
