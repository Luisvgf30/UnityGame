using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI respuesta;
    public TextMeshProUGUI felicidades;


    // Update is called once per frame
    void Update()
    {
        // Actualizar el texto en función de los valores obtenidos
        if (PlayerPrefs.GetInt("ganar") == 0)
        {
            respuesta.text = "Game Over";
            felicidades.text = $"Lastima {PlayerPrefs.GetString("nombreJugador")}... pero puedes intentarlo de nuevo!";
        }
        else
        {
            respuesta.text = "Enhorabuena";
            felicidades.text = $"Felicidades {PlayerPrefs.GetString("nombreJugador")}, ganaste la partida en {PlayerPrefs.GetString("tiempoFormateado")}";
        }
    }
}
