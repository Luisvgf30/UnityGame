using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemigo : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private bool left;
    private int nivel;


    // Start is called before the first frame update
    void Start()
    {
        left = true;
        nivel = PlayerPrefs.GetInt("nivel");

        if (nivel == 1)
        {
            velocidad = velocidad * 2;
        }
        else if (nivel == 2)
        {
            velocidad = velocidad * 3;
        }

        if (this.gameObject.CompareTag("bat"))
        {
            Destroy(this.gameObject, 12);
        }
    }

    void Update()
    {
            if (left)
            {
                if (this.gameObject.CompareTag("bat"))
                {
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    this.gameObject.transform.Translate(Vector2.left * Time.deltaTime * velocidad);
                }   
                else
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                        this.gameObject.transform.Translate(Vector2.left * Time.deltaTime * velocidad);
                    }  
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                this.gameObject.transform.Translate(Vector2.right * Time.deltaTime * velocidad);
            }

    }

    void OnCollisionEnter2D(Collision2D objeto)
    {
        if (objeto.gameObject.CompareTag("limit") && this.gameObject.CompareTag("bat"))
        {
            Destroy(this.gameObject);
        }
        else if (objeto.gameObject.CompareTag("limit"))
        {
           if (left)
            {
                left = false;
            }
            else
            {
                left = true;
            }
        }
        
    }

 

}
