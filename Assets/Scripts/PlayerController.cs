using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30f;
    private float forwardInput;

    private Rigidbody _rigidbody;
    private GameObject focalPoint;

    public bool hasPowerup;
    private float powerupForce = 15f;

    public GameObject[] powerupIndicators;

    private void Start()
    {
        //funciones de tipo:
        _rigidbody = GetComponent<Rigidbody>(); 
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
            StartCoroutine(PowerupCountDown());
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
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
        for (int i = 0; i < powerupIndicators.Length; i++)
        {
            powerupIndicators[i].SetActive(true);
            yield return new WaitForSeconds(2);
            powerupIndicators[i].SetActive(false); //setactive = se ve o no en pantalla
        }
        hasPowerup = false;
    }
}
