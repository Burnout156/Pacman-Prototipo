using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Apenas criei esse script para ativar a animação do texto e sair depois para o menu inicial
public class SplashScreen : MonoBehaviour 
{
    public MenuManager menuManager;

    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();    
    }

    //Para checar se alguma tecla foi apertada
    void Update()
    {
        if(Input.anyKey)
        {
            menuManager.SelectMenu();
        }
    }
}
