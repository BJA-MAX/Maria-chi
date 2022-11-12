using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloj : MonoBehaviour
{
    public static float tiempoReloj;  //Variable para comparar el tiempo y saber cuando spawnear la nota
    private bool seAcabo;
    
    // Start is called before the first frame update
    void Start()
    {
        seAcabo = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!Pause.isPaused && !seAcabo)
        {
            tiempoReloj = GameManager.instance.Tempo;
            GameManager.instance.Temporizador();
        }

        if ((selectorCancion.Dura + 3) < tiempoReloj)
        {
            seAcabo = true;
        }

    }

  
}
