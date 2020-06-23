using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorPelota : MonoBehaviour
{
    // Start is called before the first frame update
   
    public GameObject j1;
    public GameObject j2;

    void OnTriggerEnter(Collider other){

        if(other.tag == "Malla1"){
            
            GameObject.Find(j1.name).GetComponent<ControladorCarros>().goles += 1;
        }
        if(other.tag == "Malla2"){
            GameObject.Find(j2.name).GetComponent<ControladorCarros>().goles += 1;
            
        }
    }
}
