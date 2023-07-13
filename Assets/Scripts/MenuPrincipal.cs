using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
   //Carga la escena del juego
    public void PlayGame(){

        //Carga la escena siguiente
        SceneManager.LoadScene("Juego"); // También se podría poner por índice, nuestro caso 1.


    }


    //Sale del juego
    public void QuitGame(){

        Debug.Log("Hemos salido del juego");
        Application.Quit();

    }
}
