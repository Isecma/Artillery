using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejoDeEscenas : MonoBehaviour
{

    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
    }
    public void FinalizarJuego()
    {
        Application.Quit();
    }

    public void CargarMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SiguienteNivel()
    {
        var siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > siguienteNivel)
        {
            Canon.Bloqueado = false;
            AdministradorJuego.DisparosPorJuego = 10;
            SceneManager.LoadScene(siguienteNivel);
        }
        else
        {
            CargarMenu();
        }
    }
    public void ReintentarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AdministradorJuego.DisparosPorJuego = 10;
        Canon.Bloqueado = false;
    }
}
