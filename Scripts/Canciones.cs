using UnityEngine;
using System;
// Clase que nos permitira poder hacer el guardado de las notas usando listas
[Serializable]
public class Canciones
{
    public string Nombre;
    public int BPM;
    public bool Clear;
    public bool Unlock;
    public int Length;
    public int Score;

    public Canciones(string Name, int Bits, bool Terminada, bool Desbloqueada, int Duracion, int Puntuacion)
    {
        Nombre = Name; //Nombre de la Cancion
        BPM = Bits; //Beats Per minute
        Clear = Terminada;
        Unlock = Desbloqueada;
        Length = Duracion;
        Score = Puntuacion;
    }
}
