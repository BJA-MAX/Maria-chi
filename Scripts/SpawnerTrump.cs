using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrump : MonoBehaviour
{
    public GameObject Notita; //Elemento prefav que se spawneara

    private float Tempo;  //Variable para comparar el tiempo y saber cuando spawnear la nota
    private int _notasTotales; //Cantidad de notas en la partitura
    private List<Notas> Partitura = new List<Notas>(); //Lista de notas de la cansion
    private int i; //Contador para iterar en la lista de notas
    private string cancionEle; //Nombre de la cancion a tocar

    // Start is called before the first frame update
    void Start()
    {
        cancionEle = PlayerPrefs.GetString("cancion", "Prueba"); // Regresa la cancion almacenada en el playerprefs y si no hay ninguna por default pone prueba
        cancionEle = cancionEle + "Tromp";
        Partitura = Administrador.ReadFromJSON<Notas>(cancionEle + ".JSON",1); //Lectura de la lista guardada
        i = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.isPaused)
        {
            _notasTotales = Partitura.Count;
            Tempo = Reloj.tiempoReloj;
            if (i < _notasTotales) //Para no pedir notas fuera de la lista
            {
                if (Tempo >= Partitura[i].Tiempo) //Para detectar cuando sale la siguiente nota en la lista
                {
                    Instantiate(Notita, Partitura[i].Posiciones, Quaternion.identity);
                    i++;
                }
                    
            }


        }
        
    }
}
