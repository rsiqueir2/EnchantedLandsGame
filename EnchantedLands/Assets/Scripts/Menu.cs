
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    { 
        // Checa se a tecla "espaço" foi apertada
        if (Input.GetKey(KeyCode.Space) == true)
        { 
            // Se sim, carrega a cena "Level01"
            SceneManager.LoadScene("Level01", LoadSceneMode.Single);
        }
    }

   

    public void Sair()
    {

        Application.Quit();

    }
}

