using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    //Sensibilidad de la camara
    [SerializeField] private float sensibility = 50f;
    private float rotateX;
    //Posicion de los ojos (camara)
    [SerializeField] private Transform ojos;

    //Velocidad al andar
    [SerializeField] private float velocidad;
    //Componente que permite al jugador moverse
    private CharacterController characterController;

    [SerializeField] private Transform pies;

    //Variable que se usaria para detectar cuando los pies, colionan con el layer del hielo
    [SerializeField] private LayerMask layerHielo;

    private float radio = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //Mover la camara mediante la posicion del rato
        MoverCamara();

        //Mover el  personaje en el eje x,z
        MoverPersonaje();

        Saltar();

        detectarHielo();
    }

    public void MoverCamara()
    {

        float mouseX = Input.GetAxis("Mouse X") * sensibility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibility * Time.deltaTime;

        gameObject.transform.Rotate(Vector3.up * mouseX);


        rotateX -= mouseY;

        // rotateX = Math.Clamp(rotateX, -90,90 );

        ojos.transform.localRotation = Quaternion.Euler(rotateX, 0, 0);
    }

    public void MoverPersonaje()
    {

        float moveX = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;


        Vector3 mover = transform.right * moveX + transform.forward * moveZ ;

        characterController.Move(mover);

    }

    public void Saltar()
    {

        if (Input.GetButtonDown("Jump"))
        { 
  

        }

    }

    public void detectarHielo()
    {

        Vector3 position = (gameObject.transform.position - gameObject.transform.position).normalized;

        bool sobreHielo = Physics.CheckSphere(position, radio, layerHielo);

        if (sobreHielo)
        {
            Debug.Log("Esta sobre hielo");
        }

    }

    private void OnDrawGizmos()

    {
        Vector3 position = (gameObject.transform.position - gameObject.transform.position).normalized;

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(position, radio);
    }


}
