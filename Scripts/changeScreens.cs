using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;



public class changeScreens : MonoBehaviour
{
    public List<Notas> Nuevo = new List<Notas>();
    


    // Cambiar a la pantalla de Game1
    public void RestartGame()
    {
        
        SceneManager.LoadScene(1);
        GameManager.instance.resetPuntuacion();
        //gameObject.AddComponent<MusicPlayer>();

    }
    //Cambiar a la pantalla del menu
    public void MenuGame()
    {
        
        SceneManager.LoadScene(0);
    }
    //Cambiar a la pantalla para grabar una cancion
    public void LecturaGame()
    {
        
        SceneManager.LoadScene(2);
        //UnityEditor.AssetDatabase.Refresh();
        //gameObject.AddComponent<MusicPlayer>();

    }

}
