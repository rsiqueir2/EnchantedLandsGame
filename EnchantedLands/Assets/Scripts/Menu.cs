using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    // Use this for initialization

    public void PlayGame()
    {

        //Inicia o jogo na tela de menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //+1
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Checa se a tecla "espaço" foi apertada
        if (Input.GetKey(KeyCode.Space) == true)
        {
            // Se sim, carrega a cena "Level01"
            SceneManager.LoadScene("Level01", LoadSceneMode.Single);
        }
    }

    public void CarregaFase(int cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void Sair()
    {
        Application.Quit();
    }
}