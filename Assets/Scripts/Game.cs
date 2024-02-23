using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    public TMP_InputField inputNombre;
    public TMP_Dropdown dropdown; // Asigna el dropdown en el Inspector


    public void Jugar()
    {
        if (string.IsNullOrEmpty(inputNombre.text))
        {
            inputNombre.placeholder.GetComponent<TextMeshProUGUI>().text = "REQUERIDO";
        }
        else
        {
            // Guardar el nivel y el nombre del jugador en PlayerPrefs
            int nivel = dropdown.value;
            string nombreJugador = inputNombre.text;

            PlayerPrefs.SetInt("nivel", nivel);
            PlayerPrefs.SetString("nombreJugador", nombreJugador);
            PlayerPrefs.Save();

            SceneManager.LoadScene("Ingame");
        }
    }

    public void resert()
    {
        SceneManager.LoadScene("Ingame");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}


