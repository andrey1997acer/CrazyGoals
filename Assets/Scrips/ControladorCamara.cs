using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{
    // Start is called before the first frame update
   
    private Vector3 posicionRelativa;
    public GameObject jugador;
    void Start()
    {
        posicionRelativa = transform.position - jugador.transform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = jugador.transform.position + posicionRelativa;
        
    }
}
