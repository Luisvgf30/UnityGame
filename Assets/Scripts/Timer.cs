using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer = 0;
    public TextMeshProUGUI textoTimer;

    // Update is called once per frame
    void Update()    
    {
        timer += Time.deltaTime;

        // Calcular minutos, segundos y milisegundos
        int minutos = (int)(timer / 60);
        int segundos = (int)(timer % 60);
        int milisegundos = (int)((timer * 1000) % 1000);

        // Formatear la salida en el formato deseado (00:00:000)
        string tiempoFormateado = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milisegundos);

        // Actualizar el texto del cronómetro
        textoTimer.text = tiempoFormateado;

        PlayerPrefs.SetString("tiempoFormateado", tiempoFormateado);
        PlayerPrefs.Save();

    }
}
