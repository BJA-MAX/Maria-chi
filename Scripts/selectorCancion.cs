using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class selectorCancion : MonoBehaviour
{
    private List<Canciones>  Album= new List<Canciones>();
    private List<string> listaCanciones = new List<string>();
    /*private List<string> listaCanciones = new List<string>() { //Lista de los nombres de canciones
            "Prueba",
            "Cucaracha",
            "Again"
        };*/
    private int l=0; //Itedaror para la lista de canciones
    public static int BPM;
    public static int Dura;
    public Text cancionElegida; //Nombre de la cansion seleccionada
    // Start is called before the first frame update
    void Start()
    {
        Album = Administrador.ReadFromJSON<Canciones>("Canciones" + ".JSON",0);
        foreach (var obj in Album)
        {
            listaCanciones.Add(obj.Nombre);
        }
        //;
        cancionElegida.text = PlayerPrefs.GetString("cancion", "Prueba"); //Saca la cancion de las preferencias o saca prueba si no hay preferencias
        l = listaCanciones.IndexOf(cancionElegida.text.ToString()); //Busca la cancion en la lista de canciones para saber en que valor de la lista esta
        BPM = Album[l].BPM;
        Dura = Album[l].Length;


    }

    //Guarda la preferencia del jugador para reproducirla en otra escena
    public void setCancion()
    {
        PlayerPrefs.SetString("cancion", cancionElegida.text.ToString()); //Guarda el nombre la cancion en las preferencias con el tag "cancion"
        
        
    }

    //Funciones para cambiar la seleccion de canciones en el menu principal
    public void changeCancionDer()
    {
        //Iterador para el selector del texto hacia la derecha
        int totalCanciones = listaCanciones.Count - 1;
        if (l < totalCanciones)
        {
            l++;
        }
        else
        {
            l = 0;
        }
        cancionElegida.text = listaCanciones[l];
        BPM = Album[l].BPM;
        Dura = Album[l].Length;


    }
    public void changeCancionIzq()
    {
        //Iterador para el selector del texto hacia la izquierda
        int totalCanciones = listaCanciones.Count - 1;
        if (0 < l)
        {
            l--;
        }
        else
        {
            l = totalCanciones;
        }
        cancionElegida.text = listaCanciones[l];
        BPM = Album[l].BPM;
        Dura = Album[l].Length;

    }
}
