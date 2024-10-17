using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    
    CharacterController controller;

    void Start()
    {
        //Bloquea el raton en el centro de la pantalla y lo oculta
        Cursor.lockState = CursorLockMode.Locked;

       controller =  GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(h, v).normalized;
       
        //Si esxiste input ....
        if (input.magnitude > 0)
        { 
            //Se calcula el ángulo al que tengo que rotarme en funcion a los inputs y orientacion de la camara
        float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;          // Atan2 = arcotg de 2

        transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
        controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);

        }
    }
}