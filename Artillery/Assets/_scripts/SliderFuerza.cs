using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SliderFuerza : MonoBehaviour
{
    public AdministradorJuego adminJuego;
    public TMP_Text tagVelocidad;

    public static Slider slider;

    public void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ControlarCambios(); });

    }
    public void Update()
    {
        tagVelocidad.text = $"Fuerza: {Math.Truncate(slider.value)}";
    }

    public void ControlarCambios()
    {
        adminJuego.CambiarFuerzaDisparo(slider.value);
    }
}