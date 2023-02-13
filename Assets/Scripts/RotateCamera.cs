using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float rotationSpeed = 50f; //modificar la velocidad
    private float horizontalInput; //controladores


    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); //interaccion del usuario
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * horizontalInput); //rotamos el focal point y la cámara hace el efecto de rotar a su alrededor
    }
}
