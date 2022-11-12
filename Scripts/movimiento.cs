using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    [SerializeField] private Vector2 velocidad_fondo;
    private Vector2 offset;
    private Material mat;
    

    private void Awake()
    {
        
        mat = GetComponent<SpriteRenderer>().material;
    }

    private void Update() {
        offset = velocidad_fondo * Time.deltaTime;
        //Debug.Log(mat);
        mat.mainTextureOffset += offset;
        
        

    } 
}
