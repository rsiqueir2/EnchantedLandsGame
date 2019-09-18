using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fim : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            // Puxando o valor do Build onde estão as cenas, o Venceu é a cena 4 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}

