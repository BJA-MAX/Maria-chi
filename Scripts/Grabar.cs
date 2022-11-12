using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Grabar : MonoBehaviour
{
    //Inicializa la Cancion para Guardar
    public List<Notas> NotasMusicales = new List<Notas>(); // Lista de notas que se guardara
    private bool _puedeGrabar; // bandera para saber si se puede grabar
    private string cancionEle; // Nombre de la cancion a grabar
    public Text boton; //boton para empezar a grabar
    public GameObject AudioPlayer;
    public Text Print;
    public Transform Mastil;
    //public static string Holi = "Jol";

    //Cosas que Necesita Trompeta
    public Transform objLimite;
    private float _limiteX;
    private int _cont1;
    private int _cont2;
    private int _cont3;
    private float Tempo1;
    private float Tempo2;
    private float Tempo3;

    //Cosas que Necesita Maracas
    

    private void Start()
    {
        //Se inicia sin grabar
        cancionEle = PlayerPrefs.GetString("cancion", "Prueba"); // Regresa la cancion almacenada en el playerprefs y si no hay ninguna por default pone prueba
        _puedeGrabar = false; 
        boton.text = "Grabar";

        //Mas Cosas de Trompeta
        _limiteX = objLimite.position.x;
        _cont1 = 0;
        _cont2 = 0;
        _cont3 = 0;
        Tempo1 = 0;
        Tempo2 = 0;
        Tempo3 = 0;
    }

    void Update()
    {
        
        if (_puedeGrabar)
        {
            GameManager.instance.Temporizador();
            
        }
        
        switch (GameManager.Selector) {

            case 1:
                //Guitarra
                Debug.Log(Input.touchCount);
                if (Input.touchCount > 0) //Detecta 1 o mas toques en cualquier punto de la pantalla
                {
                    //Guarda el primer toque en pantalla y lo transforma a valores de unidad en pantalla
                    Touch touch = Input.GetTouch(0);
                    Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                    // Compara la posision del punto tocado con el espacio para tocar los botones 
                    float rangoX = Mathf.Abs(touchPos.x - Mastil.position.x);
                    float rangoY = Mathf.Abs(touchPos.y - Mastil.position.y);


                    if (Input.touchCount == 2) // Busca si hay 3 toques, queremos el segundo pero es necesario buscar el tercero
                    {
                        // Guarda el segundo toque para detectar el swipe
                        Touch touch2 = Input.GetTouch(1);
                        if (touch2.phase == TouchPhase.Ended) // Detecta cuando termina el swipe, sin importat donde se hizo o cuan largo llego
                        {
                            if (_puedeGrabar && rangoY <= 1.0f && rangoX <= 6.2) //Restringe el area donde es posible crear notas
                            {
                                float Tempo = GameManager.instance.Tempo; //Guarda el segundo en el que se toco la nota
                                                                          //Debug.Log("nota valida");
                                NotasMusicales.Add(new Notas("Guitarra", touchPos, Tempo)); //Se agrega la nota valida a la lista de notas a guardar
                                

                            }
                        }
                    }
                }
                break;
            /////////////////////////////////////////////////////////////////////////////////////////
            case 2:
                //Trompeta
                if (Input.touchCount == 1)
                {
                    Vector2 touchPos1 = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    if ((touchPos1.x) > _limiteX)
                    {
                        if (Input.GetTouch(0).phase == TouchPhase.Began)
                        {
                            Tempo1 = GameManager.instance.Tempo; //Guarda el segundo en el que se toco la nota

                        }
                        _cont1++;
                        //Debug.Log("Toque " + (toqueiD +1) + " inicio");
                        if (Input.GetTouch(0).phase == TouchPhase.Ended)
                        {
                            NotasMusicales.Add(new Notas("Trompeta", touchPos1, Tempo1, _cont1)); //Se agrega la nota valida a la lista de notas a guardar
                            Debug.Log("Toque 1 fin contador: " + _cont1 + ". Tiempo inicio: " + Tempo1);
                            _cont1 = 0;
                            Tempo1 = 0;
                        }
                    }

                }
                if (Input.touchCount == 2)
                {
                    Vector2 touchPos2 = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
                    if ((touchPos2.x) > _limiteX)
                    {
                        if (Input.GetTouch(1).phase == TouchPhase.Began)
                        {
                            Tempo2 = GameManager.instance.Tempo; //Guarda el segundo en el que se toco la nota
                        }
                        _cont2++;
                        //Debug.Log("Toque " + (toqueiD +1) + " inicio");
                        if (Input.GetTouch(1).phase == TouchPhase.Ended)
                        {

                            NotasMusicales.Add(new Notas("Trompeta", touchPos2, Tempo2, _cont2)); //Se agrega la nota valida a la lista de notas a guardar
                            Debug.Log("Toque 2 fin contador: " + _cont2 + ". Tiempo inicio: " + Tempo2);
                            _cont2 = 0;
                            Tempo2 = 0;
                        }
                    }
                }
                if (Input.touchCount == 3)
                {
                    Vector2 touchPos3 = Camera.main.ScreenToWorldPoint(Input.GetTouch(2).position);
                    if ((touchPos3.x) > _limiteX)
                    {
                        if (Input.GetTouch(2).phase == TouchPhase.Began)
                        {
                            Tempo3 = GameManager.instance.Tempo; //Guarda el segundo en el que se toco la nota
                        }
                        _cont3++;
                        //Debug.Log("Toque " + (toqueiD +1) + " inicio");
                        if (Input.GetTouch(2).phase == TouchPhase.Ended)
                        {

                            NotasMusicales.Add(new Notas("Trompeta", touchPos3, Tempo3, _cont3)); //Se agrega la nota valida a la lista de notas a guardar
                            Debug.Log("Toque 2 fin contador: " + _cont3 + ". Tiempo inicio: " + Tempo3);
                            _cont3 = 0;
                            Tempo3 = 0;
                        }
                    }

                }
                break;
            /////////////////////////////////////////////////////////////////////////////////////////
            case 3:

                Debug.Log("Chi Cheñor Soy de Rancho");
                break;

        default:
                
                break;
        }

        //Solo empieza a contar el tiempo cuando se puede grabar 
        

       
    }
    //Maneja la bandera de puedeGrabar cuando se presiona el boton
    public void botonGrabacion()
    {
        _puedeGrabar = !_puedeGrabar;
        if (_puedeGrabar) // Empieza a grabar
        {
           
            AudioPlayer.SetActive(true);
            boton.text = "Terminar"; //Cambia el texto del boton para indicar su segunda funcionalidad

        }
        else // Termina de grabar
        {
            boton.text = "Grabar";
            GameManager.Selector = 0;
            AudioPlayer.SetActive(false);
            Administrador.SaveToJSON<Notas>(NotasMusicales, cancionEle + ".JSON",1); //Guarda la lista de notas final
            Print.text = Administrador.Holi;
            
        }
        
    }

}
