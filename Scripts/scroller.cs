using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroller : MonoBehaviour
{
    // Objetos de juego necesarios
    public GameObject Notita; //Elemento prefav que se spawneara
    public Transform Papa; //Padre donde se spawnearan los objetos, tiene que ser el objeto que baja las notas
    public Transform Spawner; //Objeto referencia desde donde aparecen las notas spawneadas
    
    
    // Variables del codigo
    private float Tempo;  //Variable para comparar el tiempo y saber cuando spawnear la nota
    [SerializeField] public float tNota; //Velocidad a la que bajan las notas
    private int _notasTotales; //Cantidad de notas en la partitura
    private List<Notas> Partitura = new List<Notas>(); //Lista de notas de la cansion
    private int i; //Contador para iterar en la lista de notas
    //private string cancionEle; //Nombre de la cancion a tocar

    private void Start()
    {
        //cancionEle = PlayerPrefs.GetString("cancion", "Prueba"); // Regresa la cancion almacenada en el playerprefs y si no hay ninguna por default pone prueba
        tNota = (selectorCancion.BPM* 1.875f) / 60f; //Velodidad de la nota asumiendo 60fps
        //Partitura = Administrador.ReadFromJSON<Notas>(GameManager.instance.cancionJugar.ToString()+".JSON"); //Lectura de la lista guardada
        //Partitura = Administrador.ReadFromJSON<Notas>(cancionEle+".JSON",1); //Lectura de la lista guardada
        Partitura = controlInstrumento.Partitura;
        i = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.isPaused) //Checa si no esta en pausa
        {
            _notasTotales = Partitura.Count;
            Tempo = Reloj.tiempoReloj;

            
            if (i < _notasTotales) //Para no pedir notas fuera de la lista
            {
                if (Tempo >= Partitura[i].Tiempo) //Para detectar cuando sale la siguiente nota en la lista
                {
                    Partitura[i].Posiciones.y = Spawner.position.y; //Prepara la posicion en y con el spawner para que caiga de arriba
                    Instantiate(Notita, Partitura[i].Posiciones, Quaternion.identity, Papa); //Crea la nota en el papa que es scroller para que caiga
                                                                                             //Debug.Log("Tiempo en la lista: " + Partitura[i].Tiempo); //Parte 1 para encontrar el delay de la cansion (parte 2 en Game manager)
                    i++;
                }
            }
            

            transform.position -= new Vector3(0f, tNota * Time.deltaTime, 0f); //aqui si es necesario Vector3 porque transform.position es vector3
        }
        
        
        
    }

}
