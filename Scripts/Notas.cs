using UnityEngine;
using System;
// Clase que nos permitira poder hacer el guardado de las notas usando listas
[Serializable]
public class Notas
{
    public string Instrument;
    public Vector2 Posiciones;
    public float Tiempo;
    public int duracion;
    
    public Notas(string Name, Vector3 Pos, float Tiemp, int dur = 0) 
    {
        Instrument = Name; //Nombre del elemento en la nota, es necesario para guardarlo en el JSON
        Posiciones = Pos; //Posicion donde se guardara la nota
        Tiempo = Tiemp; //Momento en el tiempo donde se activo la nota guardada
        duracion = dur; //timepo que dura la nota activa para trompeta
    }
}
