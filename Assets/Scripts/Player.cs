using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float fuerzasalto;
    public AudioClip audioHit;
    public AudioClip audioJump;
    public AudioClip audioGem;
    private AudioSource audioSource;


    Animator animator;
    private bool saltando;
    private bool pegarcaminando;
    public GameObject prefab; // Asigna el prefab en el Inspector
    public TextMeshProUGUI gem;
    public TextMeshProUGUI nivel;

    private int gemas = 0;
    private int vidas = 3;
    private int ganar;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar el objeto Game con valores específicos
        saltando = false;
        pegarcaminando = false;
        ganar = 1;
        animator = this.GetComponent<Animator>();
        animator.SetBool("reposo", true);
        audioSource = GetComponent<AudioSource>();
        ponernivel(PlayerPrefs.GetInt("nivel"));

    }

    // Update is called once per frame
    void Update()
    {
        gem.text = gemas.ToString();

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (pegarcaminando == true)
            {
                animator.SetBool("run", false);
                animator.SetBool("reposo", false);
                animator.SetBool("hit", true);
            }
            else
            {
                animator.SetBool("run", true);
                animator.SetBool("reposo", false);
                animator.SetBool("hit", false);

            }
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.Translate(Vector3.left * Time.deltaTime * velocidad);

        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            pegarcaminando = false;
            animator.SetBool("run", false);
            animator.SetBool("reposo", true);
            animator.SetBool("hit", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (pegarcaminando == true)
            {
                animator.SetBool("run", false);
                animator.SetBool("reposo", false);
                animator.SetBool("hit", true);
                
            }
            else
            {
                animator.SetBool("run", true);
                animator.SetBool("reposo", false);
                animator.SetBool("hit", false);
                
            }
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            this.gameObject.transform.Translate(Vector3.right * Time.deltaTime * velocidad);
        }

        if (Input.GetKey(KeyCode.Space) && !(saltando))
        {
            audioSource.PlayOneShot(audioJump);
            animator.SetBool("run", false);
            animator.SetBool("reposo", false);
            animator.SetBool("saltar", true);
            animator.SetBool("hit", false);
            saltando = true;
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzasalto);
        }    
    }

    void OnCollisionEnter2D(Collision2D objeto)
    {
        if (objeto.gameObject.CompareTag("saltoon") || objeto.gameObject.CompareTag("limit") || objeto.gameObject.CompareTag("casa"))
        {
            animator.SetBool("saltar", false);
            saltando = false;
            pegarcaminando = false;
            PlayerPrefs.SetInt("ganar", ganar);
            PlayerPrefs.Save();
        }
        if (objeto.gameObject.CompareTag("gema"))
        {
            audioSource.PlayOneShot(audioGem);
            Destroy(objeto.gameObject);
            gemas++;
            generarCasa();
        }
        if (objeto.gameObject.CompareTag("bat") || objeto.gameObject.CompareTag("enemigo"))
        {
            audioSource.PlayOneShot(audioHit);
            pegarcaminando = true;
            animator.SetBool("run", false);
            animator.SetBool("hit", true);
            animator.SetBool("reposo", false);
            animator.SetBool("saltar", false);
            destruirvidas(vidas);
        }
        if (objeto.gameObject.CompareTag("casa") && gemas == 4)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    public void generarCasa()
    {
        if (gemas == 4)
        {
            // Genera el objeto en la posición (0, 0, 0) y sin rotación
            Instantiate(prefab, new Vector2(121, -2), Quaternion.identity);
        }
    }

    public void destruirvidas(int vida)
    {
        if (vida == 3)
        {
            --vidas;
            Destroy(GameObject.FindWithTag("vida1"));
        }
        else if (vida == 2)
        {
            --vidas;
            Destroy(GameObject.FindWithTag("vida2"));
        }
        else
        {
            ganar = 0;
            PlayerPrefs.SetInt("ganar", ganar);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameOver");
        }
    }

    public void ponernivel(int level)
    {
        ++level;
        nivel.text = string.Format("{0}", level);
    }
}
