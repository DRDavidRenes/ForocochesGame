using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Instancia publica de la propia clase para tener control sobre el SoundManager
    public static SoundManager instance;

    // El atributo source para obtener el Audio Source del SoundManager
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos consigo misma la instancia de la clase
        instance = this;

        //Traemos el componente AudioSource
        source = GetComponent<AudioSource>();
    }

    // El metodo PlaySound reproducira el AudiClip que se le pase como atributo.
    public void PlaySound (){
        source.Play();
    }
}
