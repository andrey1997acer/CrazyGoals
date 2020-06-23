using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControladorCarros : MonoBehaviour
{
    private float DirHorizontal;
    private float DirVertical;
    private float steerAngle;

    public WheelCollider WheelCFR, WheelCFL, WheelCBR, WheelCBL;
    public Transform WheelTFR, WheelTFL, WheelTBR, WheelTBL;
    public float maxSteerAngle = 30;
    public float motorForce = 300;
    public float brakes = 0;
    public string inputHorizontal;
    public string inputVertical;

    public List<KeyCode> keys = new List<KeyCode>();
    //public GameObject power;
    private bool powerUp1 = false;
    private bool powerUp2 = false;
    private bool powerUp3 = false;
    

    private Rigidbody rb;
    public GameObject objetoCarro;

    public int goles = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void DirectionsInput()
    {
        DirHorizontal = Input.GetAxis(inputHorizontal);
        DirVertical = Input.GetAxis(inputVertical);
    }

    public void steerControl()
    {
        steerAngle = maxSteerAngle * DirHorizontal;
        WheelCFR.steerAngle = steerAngle;
        WheelCFL.steerAngle = steerAngle;
    }

    public void speedControl()
    {
        if ((Input.GetKeyDown(keys[0]) && powerUp1)) //PODER mas velocidad
        {
            int cont = 0;
            while (cont < 100)
            {

                if (DirVertical == 0 || Input.GetKey(KeyCode.Space))
                {
                    brakes = 300;
                }
                else
                {
                    Debug.Log("Multiplicando la fuerza...... ");
                    brakes = 0;
                    WheelCFR.motorTorque = DirVertical * motorForce * 100;
                    WheelCFL.motorTorque = DirVertical * motorForce * 100;
                    WheelCBR.motorTorque = DirVertical * motorForce * 100;
                    WheelCBL.motorTorque = DirVertical * motorForce * 100;
                }

                WheelCFR.brakeTorque = brakes;
                WheelCFL.brakeTorque = brakes;
                WheelCBR.brakeTorque = brakes;
                WheelCBL.brakeTorque = brakes;

                powerUp1 = false;
                Debug.Log("Poder 1 activado...... ");

                cont = cont +1;
            }

        }
        else
        {

            if (DirVertical == 0 || Input.GetKey(KeyCode.Space))
            {
                brakes = 300;
            }
            else
            {
                Debug.Log("Normalizando la fuerza...... ");
                brakes = 0;
                WheelCFR.motorTorque = DirVertical * motorForce;
                WheelCFL.motorTorque = DirVertical * motorForce;
                WheelCBR.motorTorque = DirVertical * motorForce;
                WheelCBL.motorTorque = DirVertical * motorForce;
            }

            WheelCFR.brakeTorque = brakes;
            WheelCFL.brakeTorque = brakes;
            WheelCBR.brakeTorque = brakes;
            WheelCBL.brakeTorque = brakes;

        }

    }

    public void wheelPositionControl()
    {
        wheelPositionControls(WheelCFR, WheelTFR);
        wheelPositionControls(WheelCFL, WheelTFL);
        wheelPositionControls(WheelCBR, WheelTBR);
        wheelPositionControls(WheelCBL, WheelTBL);
    }

    public void wheelPositionControls(WheelCollider collide, Transform trans)
    {
        Vector3 wheelPosition = trans.position;
        Quaternion wheelQuant = trans.rotation;

        collide.GetWorldPose(out wheelPosition, out wheelQuant);

        trans.position = wheelPosition;
        trans.rotation = wheelQuant;
    }

    public void poder()
    {

        if ((Input.GetKeyDown(keys[0]) && powerUp2)) //PODER
        {
            
            rb.position += Vector3.up * 2;
            powerUp2 = false;
            Debug.Log("Poder 2 activado...... ");
            
        }
        if ((Input.GetKeyDown(keys[0]) && powerUp3)) //PODER
        {
            // GameObject fireBall = Instantiate(power, new Vector3(rb.position.x, rb.position.y + 5, rb.position.z), transform.rotation) as GameObject;
            //fireBall.transform.Translate(Vector3.forward * 5); //el poder aparece delante del personaje
            powerUp3 = false;
            Debug.Log("Poder 3 activado...... ");
            //attack = true;
            //sound.PlayOneShot(audios[1]); //Sonido de poder
        }
    }

    public void FixedUpdate()
    {
        DirectionsInput();
        steerControl();
        speedControl();
        wheelPositionControl();
        poder();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item1")
        {
            powerUp1 = true;
            Debug.Log("He obtenido el " + other.name);
            Destroy(other.gameObject);
        }
        if (other.tag == "Item2")
        {
            powerUp2 = true;
            Debug.Log("He obtenido el " + other.name);
            Destroy(other.gameObject);
        }
        if (other.tag == "Item3")
        {
            powerUp3 = true;
            Debug.Log("He obtenido el " + other.name);
            Destroy(other.gameObject);
        }
        if (other.tag == "Piso")
        {
            Debug.Log("He obtenido el " + other.name);
             //Destroy(this.gameObject, (float)5);
           // Instantiate(objetoCarro);
           
            
        }
    }


}
