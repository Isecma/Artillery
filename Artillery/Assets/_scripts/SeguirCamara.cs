using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamara : MonoBehaviour
{

    public static GameObject objetivo;

    [Header("Configurar un Editor")]
    public float suavizado = 0.05f;
    public Vector2 limiteXY = Vector2.zero;

    [Header("Configuraci�n Din�mica")]
    public float camZ;

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        Vector3 destino;

        if (objetivo == null)
        {
            destino = Vector3.zero;
        }
        else
        {
            destino = objetivo.transform.position;
            if (objetivo.tag == "Bala")
            {
                bool sleeping = objetivo.GetComponent<Rigidbody>().IsSleeping();
                if (sleeping)
                {
                    objetivo = null;
                    destino = Vector3.zero;
                    Canon.Bloqueado = false;
                    return;
                }
            }
            
        }
        destino.x = Mathf.Max(limiteXY.x, destino.x); //Toma el m�s grande de ambos n�meros, en caso de que destino.x sea negativo, limiteXY.x es igual a 0
        destino.y = Mathf.Max(limiteXY.y, destino.y);
        destino = Vector3.Lerp(transform.position, destino, suavizado); //Interpolaci�n
        destino.z = camZ;
        transform.position = destino;
        Camera.main.orthographicSize = destino.y + 20;
    }
}
