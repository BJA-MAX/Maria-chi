using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nota : MonoBehaviour
{
    
    public CircleCollider2D hit;
    public bool puedeApretar; // Bandera para saber si la nota esta en la zona para apretar
    private Vector2 _fingerDownPos; //Posicion del segundo toque al tocar la pantalla
    private Vector2 _fingerUpPos; //Posicion del segundo toque al soltar la pantalla
    private float _fingerDis; // Distancia de swipe de la pantalla
    [SerializeField] private float _minDistSwipe = 2.5f; // Distancia minima para considerar el swipe como valido, es editable en juego
    public Animator animador;

    private void Start()
    {
        
        animador = GetComponent<Animator>();
        hit = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        if (Input.touchCount > 0) 
        {
            //Guarda el primer toque en pantalla y lo transforma a valores de unidad en pantalla
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            //Compara la posision del punto tocado con la posicion de la nota
            float rangoX = Mathf.Abs(touchPos.x - transform.position.x);
            float rangoY = Mathf.Abs(touchPos.y - transform.position.y);


            if (Input.touchCount == 2) //Busca si hay 3 toques, queremos el segundo pero es necesario buscar el tercero
            {
                //Guarda el segundo toque para detectar el swipe
                Touch touch2 = Input.GetTouch(1);

                if (touch2.phase == TouchPhase.Began) //Detecta cuando empieza el swipe, sin importat donde se hizo 
                {
                    _fingerDownPos = Camera.main.ScreenToWorldPoint(touch2.position); //Guarda la posicion del toque para comparar despues
                    
                }
                if (touch2.phase == TouchPhase.Ended) //Detecta cuando termina el swipe, sin importat donde se hizo 
                {
                    _fingerUpPos = Camera.main.ScreenToWorldPoint(touch2.position); //Guarda la posicion del toque para comparar despues
                    _fingerDis = (_fingerDownPos - _fingerUpPos).magnitude; //Determina la distancia total de Swipeo
                    
                    if (puedeApretar && rangoX < 0.8 && _fingerDis >_minDistSwipe) //Compara el toque en x con la pantalla para validar que toco cerca, y si el swipeo fue suficientemente largo
                    {
                        //animador.SetBool("Atinada", true);
                        animador.SetTrigger("Atinada");
                        hit.enabled = false;
                        //gameObject.SetActive(false); //Desaparece la nota si se toco

                        if (rangoY < 0.2) //Rango en Y para determinar que tan cerca estuvo de tocarla justo a tiempo
                        {
                            //Es Perfecto
                            GameManager.instance.notaAtinada(0);
                        }else if(rangoY < 0.4)
                        {
                            // Es Great
                            GameManager.instance.notaAtinada(1);
                        }
                        else
                        {
                            // Es Good
                            GameManager.instance.notaAtinada(2);
                        }
                        

                    }

                }
            }
        }
    }
    //Maneja el evento de contacto entre la nota y un objeto con tags especificas
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activador")
        {
            //Imagen.color = Color.red;
            
            puedeApretar = true;
            
        }
        else if (other.tag == "Fallido")
        {
            GameManager.instance.notaFallada();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    // Maneja el evento cuando deja de haber contacto entre la nota y el objeto activador
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activador")
        {
            puedeApretar = false;
        }
    }


}
