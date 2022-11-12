using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlInstrumento : MonoBehaviour
{
    public static List<Notas> Partitura = new List<Notas>();
    public GameObject Guitarra;
    public GameObject Trompetas;
    private string cancionEle;
    public static List<Notas> NGuitarra = new List<Notas>();
    public static List<Notas> NTrompeta = new List<Notas>();
    public static List<Notas> NMaracas = new List<Notas>();

    private void Start()
    {
        cancionEle = PlayerPrefs.GetString("cancion", "Prueba");
        Partitura = Administrador.ReadFromJSON<Notas>(cancionEle + ".JSON", 1); //Lectura de la lista guardada
        foreach (var obj in Partitura)
        {
            if (obj.Instrument == "Guitarra")
            {
                NGuitarra.Add(obj);
                
            }
            else if (obj.Instrument == "Trompeta")
            {
                NTrompeta.Add(obj);
            }
            else
            {
                NMaracas.Add(obj);
            }

        }
    }
    public void actGuitarra()
    {
        GameManager.Selector = 1;
        Debug.Log("Guitarra act");
        Trompetas.SetActive(false);
        Guitarra.SetActive(true);
    }

    public void actTromp()
    {
        Debug.Log("Trompeta act");
        GameManager.Selector = 2;
        Guitarra.SetActive(false);
        Trompetas.SetActive(true);
        
    }

}
