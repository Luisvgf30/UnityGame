using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generarbichos : MonoBehaviour
{
    [SerializeField] private GameObject murcielago;
    [SerializeField] private float aparicion;
    private float y;
    private int nivel;
    // Start is called before the first frame update
    void Start()
    {
        nivel = PlayerPrefs.GetInt("nivel");
       
        if (nivel == 1)
        {
            aparicion = aparicion - 1;
        }
        else if (nivel == 2)
        {
            aparicion = aparicion - 2;
        }

        InvokeRepeating("generarbat", 0, aparicion);
    }

    void generarbat()
    {
        y = Random.Range(-6.0f, 38.0f);
        GameObject bat = Instantiate(
               murcielago,
               new Vector2(180.18f, y),
               Quaternion.identity  
           );
    }

}
