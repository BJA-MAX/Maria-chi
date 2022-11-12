using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    //Variables 
    public static GameManager instance; //Para poder ser  instanseado en otros lados
    public static int puntuacion; 
    private int puntoPorNota = 1;   //Punto base de las notas
    public float Tempo; //Contador del tiempo
    private int Duracion;
    public static int Selector =0;

    
        
    //Objetos de juego
    public Text scoreText;  // El texto que cambia con los puntos
    public Text scoreTextEnd;  // El texto que cambia con los puntos
    public Text reloj; //El texto que cambia con el tiempo
    public GameObject screenFinal; //Pantalla de final de la cancion
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        Duracion = selectorCancion.Dura;
        
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Game1" || scene.name == "Lectura")
        {
            puntuacion = 0;
            Tempo = 0;
        }
        
        scoreText.text = puntuacion.ToString();
        instance = this;
        
    }
    //Reinicia los puntos al empezar a jugar
    public void resetPuntuacion()
    {
        puntuacion = 0;
        scoreText.text = puntuacion.ToString();
    }
    //Comportamiento cuando la nota es atinada, para uso general de cualquier instrumento
    public void notaAtinada(int precision)
    {
        //Debug.Log("Nota atinada en: " + Tempo); //Parte 2 para encontrar el delay de la cansion 
        if (precision == 0)
        {
            puntuacion += (puntoPorNota * 3);
            //Debug.Log("Perfect");
        }else if (precision == 1)
        {
            puntuacion += (puntoPorNota * 2);
            //Debug.Log("Greate");
        }
        else{
            puntuacion += (puntoPorNota * 1);
            //Debug.Log("God");
        }
        scoreText.text = puntuacion.ToString();
    }
    //Comportamiento cuando la nota es fallada, para uso general de cualquier instrumento
    public void notaFallada()
    {
        Debug.Log("Nota Fallada");
        puntuacion -= puntoPorNota;
        scoreText.text = puntuacion.ToString();
    }
    //Temporizador, aumenta y cambia el texto del reloj cada que es llamada
    public void Temporizador()
    {
       
        reloj.text = Tempo.ToString("F2");
        Tempo += Time.deltaTime;
    }

    private void Update()
    {
        
        if (Tempo > (Duracion + 3))
        {
            screenFinal.SetActive(true);
            scoreTextEnd.text = puntuacion.ToString();
            
        }
    }






}

