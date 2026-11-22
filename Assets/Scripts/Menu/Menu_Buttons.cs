using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu_Buttons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jogar()
    {
        //Mudar cena jogo
        SceneManager.LoadScene("Game");
    }

    public void Options()
    {
        //Mudar cena options
        SceneManager.LoadScene("Menu_Options");
    }

    public void Creditos()
    {
        //Mudar cena creditos
        SceneManager.LoadScene("Menu_Creditos");
    }

    public void Sair()
    {
        Application.Quit();
    }
}
