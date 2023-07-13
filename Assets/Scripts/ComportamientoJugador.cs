using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoJugador : MonoBehaviour
{
    
    //Creamos un atributo Rigidbody2D para aplicar las fuerzas
    Rigidbody2D rb2d;
    //Creamos un int que representa la velocidad y direccion del movimiento
     public float speed=5;
    //El objeto que maneja Sprites del jugador 
    SpriteRenderer spriter;

    //El objeto que maneja Animaciones del jugador 
    Animator animator;


    


    // Start se llama al iniciar el juego
    void Start()
    {
        //Obtenemos el Rigidbody2d que tenga el objeto al que asociaremos el script
        //Si no hacemos eso estariamos usando un rigidbody recien creado que no está asociado al objeto
        rb2d = GetComponent<Rigidbody2D>();

        //Obtenemos el SpriteRenderer que tenga el objeto al que asociaremos el script
        spriter = GetComponent<SpriteRenderer>();

        //Obtenemos el Animator que tenga el objeto al que asociaremos el script
        animator = GetComponent<Animator>();
        
    }

    // FixesUpdate es una funcion de unity que se ejecuta antes de representar y calcular las fisicas.
    void FixedUpdate()
    {
       //LLamamos al metodo movePlayer que va a mover al jugador, referencia al eje horizontal del InputManager
       MovePlayer(
           Input.GetAxisRaw("Horizontal")*speed,
           Input.GetAxisRaw("Vertical")*speed);

    }

    void MovePlayer(float moveX,float moveY){

        //Usamos el atributo flipX para que el sprite cambie la orientacion firando en la X
        //Si el movimiento de X es positivo no gira el jugador, si es negativo lo gira y si es 0 no hace nada
        if(moveX>0){
            spriter.flipX=false;
        }
        else if (moveX<0){
            spriter.flipX=true;
        }


        //Asignamos a la variable Velocidad (del animator) el valor de la variable moveX (del Script)
        if(moveX!=0)
            animator.SetInteger("Velocidad",(int)moveX);
        else{
            animator.SetInteger("Velocidad",(int)moveY);
        }

        //Cambiamos la velocidad horizontal y vertical con el valor de movimiento que nos pasa la funcion 
        rb2d.velocity = new Vector2(moveX,moveY);
        
    }

    //Metodo que salta cuando entra en colision (OnTrigger)
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name=="alonsoPole"){

            //Llama al gameManager para indicar que hemos hecho una pole
            GameManager.instance.HacerPole();
            //Cada vez que hacemos una pole suena
            SoundManager.instance.PlaySound();
            //Mas velocidad para aumentar la dificultad
            speed=speed*1.2F;

        }
        else{ //Si es un fail 

            //Llama al gameManager para indicar que hemos muerto, DEP Siempre saludaba
            GameManager.instance.GameOver();
            //SoundManager.instance.PlaySound();
            Destroy(other.gameObject);
            Destroy(gameObject);
            

        }
        
    }
}
