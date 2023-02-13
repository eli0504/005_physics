using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 4;
    private float yMin = -4;
    private Rigidbody _rigidbody;
    private GameObject player;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized; //cálculo de la dirección enemigo -> player

        _rigidbody.AddForce(direction * speed); //se aplica una fuerza sobre el rigidbody del enemigo hacia el player a la misma velocidad

        if (transform.position.y < yMin) //comprueba si se ha caido y si ha caido por debajo del límite, el enemigo se destruye
        {
            Destroy(gameObject);
        }
    }
}
