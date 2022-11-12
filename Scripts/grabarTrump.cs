using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class grabarTrump : MonoBehaviour
{
    public Transform objLimite;
    private float _limiteX;
    public List<Notas> NotasMusicales = new List<Notas>(); // Lista de notas que se guardara
    private bool _puedeGrabar; // bandera para saber si se puede grabar
    private string cancionEle; // Nombre de la cancion a grabar

    public Text boton; //boton para empezar a grabar
    public GameObject AudioPlayer;
    public Text Print;

    private int _cont1;
    private int _cont2;
    private int _cont3;
    private float Tempo1;
    private float Tempo2;
    private float Tempo3;

    // Start is called before the first frame update
    void Start()
    {
        //Se inicia sin grabar
        cancionEle = PlayerPrefs.GetString("cancion", "Prueba"); // Regresa la cancion almacenada en el playerprefs y si no hay ninguna por default pone prueba
        cancionEle = cancionEle + "Tromp";
        _puedeGrabar = false;
        boton.text = "Grabar";
        _limiteX = objLimite.position.x;
        _cont1 = 0;
        _cont2 = 0;
        _cont3 = 0;
        Tempo1 = 0;
        Tempo2 = 0;
        Tempo3 = 0;

    }

    // Update is called once per frame
    void Update()
    {
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
                    NotasMusicales.Add(new Notas("Touch" + Input.touches[0].fingerId, touchPos1, Tempo1, _cont1)); //Se agrega la nota valida a la lista de notas a guardar
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

                    NotasMusicales.Add(new Notas("Touch" + Input.touches[1].fingerId, touchPos2, Tempo2, _cont2)); //Se agrega la nota valida a la lista de notas a guardar
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

                        NotasMusicales.Add(new Notas("Touch" + Input.touches[2].fingerId, touchPos3, Tempo3, _cont3)); //Se agrega la nota valida a la lista de notas a guardar
                        Debug.Log("Toque 2 fin contador: " + _cont3 + ". Tiempo inicio: " + Tempo3);
                        _cont3 = 0;
                        Tempo3 = 0;
                    }
                }

            }

        //Solo empieza a contar el tiempo cuando se puede grabar 
        if (_puedeGrabar)
        {
            GameManager.instance.Temporizador();
        }
    }

   
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
            AudioPlayer.SetActive(false);
            NotasMusicales = Enumerable.Reverse(NotasMusicales).ToList();
            Administrador.SaveToJSON<Notas>(NotasMusicales, cancionEle + ".JSON",1); //Guarda la lista de notas final
            Print.text = Administrador.Holi;

        }

    }
}
