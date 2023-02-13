using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3f;
    private float forwardInput;
    private Rigidbody _rigidbody;
    private GameObject focalPoint;
    private bool hasPowerup, hasPowerup2;
    private float powerupForce = 15f;
    private float originalScale = 1.5f;
    private float powerupScale = 2f; // escala aumentada por el powerup

    public GameObject[] powerupIndicators;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        //función de tipo:
        focalPoint = GameObject.Find("Focal Point"); 
    }

    private void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * speed * forwardInput); //empujando hacia alante o hacia atras
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDown());
        }

        if(other.gameObject.CompareTag("Powerup Scale"))
        {
            hasPowerup2 = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDown());
        }
    }

    private void OnCollisionEnter(Collision other) //no hay ningún trigger
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(awayFromPlayer * powerupForce, ForceMode.Impulse);
        }
    }

    private IEnumerator PowerupCountDown()
    {
        if (hasPowerup2)
        {
            transform.localScale = powerupScale * Vector3.one;
        }
        for (int i = 0; i < powerupIndicators.Length; i++)
        {
            powerupIndicators[i].SetActive(true);
            yield return new WaitForSeconds(2);
            powerupIndicators[i].SetActive(false); //SetActive = se ve o no en pantalla
        }

        if (hasPowerup2)
        {
            transform.localScale = originalScale * Vector3.one;
        }

        hasPowerup = false;
        hasPowerup2 = false;
    }
}
