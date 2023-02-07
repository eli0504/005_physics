using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUCLES : MonoBehaviour
{
    public string[] names;

    public Vector3[] positions;
    public GameObject prefab;

    private void Start()
    {
        //imprimir los 100 primeros números
        for (int i = 1; i<=10; i++)
        {
            Debug.Log(i);
        }

        //tabla de multiplicar del 10
        for (int i = 1; i<=10; i++)
        {
            Debug.Log($"10 x {i} = {10 * i}");
        }

        //Recorer un array
        for (int i = 0; i < names.Length; i++)
        {
            Debug.Log(names[i]);
        }

        //instanciar elementos
        for(int i = 0; i < positions.Length; i++)
        {
            Instantiate(prefab, positions[i], Quaternion.identity);
        }

        //versión foreach => específico para recorrer colecciones
        foreach(Vector3 p in positions)
        {
            Instantiate(prefab, p, Quaternion.identity);
        }

        //Crea un bucle while que muestre la tabla del 9
        int a = 1;
        while (a <= 10)
        {
            Debug.Log($"9 x {a} = {9 * a}");
            a++;
        }


    }
}
