using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Text lbl_goalj1;
    public Text lbl_goalj2;
    public Text lbl_tiempo;

    public float intervalo = 30f;


    

    void Start(){
        setMarcador();
        startCountDown();
    }

    void Update(){
        setMarcador();
        lbl_tiempo.text = intervalo.ToString(); 
    }
     void setMarcador()
    {
        int j1 = GameObject.Find("jeep1").GetComponent<ControladorCarros>().goles;
        int j2 = GameObject.Find("jeep2").GetComponent<ControladorCarros>().goles;
        lbl_goalj1.text = j1.ToString();
        lbl_goalj2.text = j2.ToString();
    }

    public void startCountDown(){
        StartCoroutine("setTime");
    }

    IEnumerator setTime()
    {
        intervalo -= 1;
        yield return new WaitForSeconds(1);
        StartCoroutine("setTime");  
    }
}
