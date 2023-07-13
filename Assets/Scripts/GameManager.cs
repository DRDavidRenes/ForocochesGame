using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Objeto alonso demigrante para poder ver si ha colisionado con el
    //Añadiremos el objeto a esta propiedad
    public GameObject alonsoPole;
    //Objeto fail para ir creandolos 
    public GameObject fail; 
   
    public GameObject BotonMenuPrincipal;
    public static GameManager instance;
    

    //Variable con la puntuacion 
    int puntuacion;


    // Start is called before the first frame update
    void Start()
    {
        //Tiene que llamarse a si mismo
        //Para saber que solo existe un GameManager
        if(instance==null)
            instance=this;
        if(instance!=this)
            Destroy(this);

        puntuacion=0;
        BotonMenuPrincipal.SetActive(false); //Quitamos el boton de volver

    
        
    }


    //Metodo hacerPole() se llamara cuando colisionemos con una moneda
    public void HacerPole(){
        
        puntuacion++;
        

        //Condicion de victoria
        if(puntuacion>5){
           Debug.Log("VICTORIA, ERES UN MACHO ALFA");

        }
        

        //Movemos la pole aleatoriamente
        alonsoPole.transform.position = new Vector2 (Random.Range(-7f,8f),Random.Range(-5f,5f));
        //Instancie un fail en una posicion aleatoria cada vez que coge una pole
        Instantiate(fail,new Vector2 (Random.Range(-7f,7f),Random.Range(-5f,5f)),Quaternion.identity);



    }

    //El metodo GameOver se llamará cuando toquemos un fail
    public void GameOver(){
        Debug.Log("D.E.P.   Siempre saludaba");
        BotonMenuPrincipal.SetActive(true);
        

    }

}
