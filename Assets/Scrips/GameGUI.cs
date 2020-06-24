using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUI : MonoBehaviour
{
    // Start is called before the first frame update

    public Text lbl_goalj1;
    public Text lbl_goalj2;

    public RawImage lbl_poderj1;
    public RawImage lbl_poderj2;
    public Text lbl_tiempo;

    public float intervalo = 30f;

    public List<KeyCode> keys = new List<KeyCode>();
    public GameObject pauseMenu;
    public bool pauseGame = false;
    public Text lbl_gameover;


    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        setMarcador();
        startCountDown();
        pause();
        lbl_poderj1.enabled = false;
        lbl_poderj2.enabled = false;
        lbl_gameover.enabled = false;

    }

    void Update()
    {
        setMarcador();
        lbl_tiempo.text = intervalo.ToString();






        if (GameObject.Find("jeep1").GetComponent<ControladorCarros>().volcado)
        {
            GameObject.Find("jeep1").transform.eulerAngles = new Vector3(
                0f,
                -90f,
                0f
                );
            GameObject.Find("jeep1").GetComponent<ControladorCarros>().volcado = false;
        }
        if (GameObject.Find("jeep2").GetComponent<ControladorCarros>().volcado)
        {
            GameObject.Find("jeep2").transform.eulerAngles = new Vector3(
                0f,
                90f,
                0f
                );
            GameObject.Find("jeep2").GetComponent<ControladorCarros>().volcado = false;
        }

        if (GameObject.Find("jeep1").GetComponent<ControladorCarros>().powerUp1 || GameObject.Find("jeep1").GetComponent<ControladorCarros>().powerUp2)
        {
            lbl_poderj1.enabled = true;
        }
        else
        {
            lbl_poderj1.enabled = false;
        }
        if (GameObject.Find("jeep2").GetComponent<ControladorCarros>().powerUp1 || GameObject.Find("jeep2").GetComponent<ControladorCarros>().powerUp2)
        {
            lbl_poderj2.enabled = true;
        }
        else
        {
            lbl_poderj2.enabled = false;
        }

        if (Input.GetKeyDown(keys[0])) //Pausa
        {
            if (pauseGame)
            {
                resume();
            }
            else
            {
                pause();
            }
        }

        if (intervalo <= 0)
        {

            gameOver();
            intervalo = 0;


            if (GameObject.Find("jeep1").GetComponent<ControladorCarros>().goles > GameObject.Find("jeep2").GetComponent<ControladorCarros>().goles)
            {
                lbl_gameover.enabled = true;
                lbl_gameover.text = "¡JUGADOR 1 GANA!";
                gameOver();

            }
            else if (GameObject.Find("jeep2").GetComponent<ControladorCarros>().goles > GameObject.Find("jeep1").GetComponent<ControladorCarros>().goles)
            {
                lbl_gameover.enabled = true;
                lbl_gameover.text = "¡JUGADOR 2 GANA!";
                gameOver();
            }
            else
            {
                lbl_gameover.enabled = true;
                lbl_gameover.text = "EMPATE";
                gameOver();
            }

        }
    }
    void setMarcador()
    {
        int j1 = GameObject.Find("jeep1").GetComponent<ControladorCarros>().goles;
        int j2 = GameObject.Find("jeep2").GetComponent<ControladorCarros>().goles;

        if (lbl_goalj1.text != j1.ToString())
        {
            GameObject.Find("jeep2").transform.position = new Vector3(-3.62f, 0.37f, 0.32f);
            GameObject.Find("jeep1").transform.position = new Vector3(3.62f, 0.37f, 0.32f);
            GameObject.Find("Balon").transform.position = new Vector3(0.24f, 3.75f, 0.54f);

        }
        if (lbl_goalj2.text != j2.ToString())
        {
            GameObject.Find("jeep2").transform.position = new Vector3(-3.62f, 0.37f, 0.32f);
            GameObject.Find("jeep1").transform.position = new Vector3(3.62f, 0.37f, 0.32f);

            GameObject.Find("Balon").transform.position = new Vector3(0.24f, 3.75f, 0.54f);
        }

        lbl_goalj1.text = j1.ToString();
        lbl_goalj2.text = j2.ToString();
    }

    public void startCountDown()
    {
        StartCoroutine("setTime");
    }

    IEnumerator setTime()
    {
        intervalo -= 1;
        yield return new WaitForSeconds(1);
        StartCoroutine("setTime");
    }

    public void pause()
    {
        pauseGame = true;
        pauseMenu.SetActive(pauseGame);
        Time.timeScale = 0f; //se detiene el juego
    }

    public void resume()
    {
        pauseGame = false;
        pauseMenu.SetActive(pauseGame);
        Time.timeScale = 1f; //se reanuda el juego
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void loadGame()
    {
        GameObject.Find("jeep1").GetComponent<ControladorCarros>().goles = 0;
        GameObject.Find("jeep2").GetComponent<ControladorCarros>().goles = 0;
        SceneManager.LoadScene("ecena1");
    }



    public void gameOver()
    {
        StartCoroutine("endGame");
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(1);
        pause();
    }
}
