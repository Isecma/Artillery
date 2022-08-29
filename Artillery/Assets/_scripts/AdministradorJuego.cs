using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego SingletonAdministradorJuego;
    public static float VelocidadBala = 30;
    public static int DisparosPorJuego = 10;
    public static float VelocidadRotacion = 0.5f;

    public GameObject CanvasGanar;
    public GameObject CanvasPerder;

    private void Awake()
    {
        if (SingletonAdministradorJuego == null)
        {
            SingletonAdministradorJuego = this;
        }
        else
        {
            Debug.LogError("Ya existe una instancia de esta clase");
        }
    }

    private void Update()
    {
        if (DisparosPorJuego == 0 && CanvasGanar.activeSelf == false)
        {
            Invoke("PerderJuego", 5);
            Canon.Bloqueado = true;
        }
    }

    public void GanarJuego()
    {
        CanvasGanar.SetActive(true);
    }

    public void PerderJuego()
    {
        CanvasPerder.SetActive(true);
    }

    public void CambiarFuerzaDisparo(float nuevaVelocidad)
    {
        VelocidadBala = nuevaVelocidad;
    }

}
