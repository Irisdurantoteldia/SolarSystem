using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{
    public float acceleration = 5f;         // Cuánto se acelera la nave al presionar W
    public float deceleration = 3f;         // Cuánto se desacelera la nave al presionar S
    public float maxSpeed = 200f;           // Velocidad máxima hacia adelante
    public float turnSpeed = 5f;            // Velocidad de giro
    public float mouseSensitivity = 3f;     // Sensibilidad del ratón

    private float currentSpeed = 0f;        // Velocidad actual de la nave

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;   // Bloquea el cursor en el centro de la pantalla
    }

    private void Update()
    {
        HandleRotation();
        HandleMovement();
    }

    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = new Vector3(-mouseY * mouseSensitivity, mouseX * mouseSensitivity, 0);
        transform.Rotate(rotation, Space.Self);
    }

    private void HandleMovement()
    {
        float vertical = Input.GetAxis("Vertical");

        if (vertical > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (vertical < 0)
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }

        // Asegurarse de que la velocidad actual no exceda la velocidad máxima y no sea negativa
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        // Mueve la nave hacia adelante según su velocidad actual
        Vector3 movement = new Vector3(0, 0, currentSpeed * Time.deltaTime);
        rb.velocity = transform.TransformDirection(movement);
    }
}