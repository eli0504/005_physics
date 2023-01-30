using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed; //modificar la velocidad
    private float horizontalInput; //controladores

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); //interaccion del usuario
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * horizontalInput); 
    }
}
