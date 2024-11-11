using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anima;
    public float x, y;

    public Rigidbody rb;
    public float fuerzaDeSalto = 8;
    public bool puedoSaltar;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        puedoSaltar = false;
    }

    private void FixedUpdate(){
        transform.Translate(0,0,y * Time.deltaTime * velocidadMovimiento);
        transform.Rotate(0,x * Time.deltaTime * velocidadRotacion,0);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");        

        anima.SetFloat("EjeX", x);
        anima.SetFloat("EjeY", y);

        if(puedoSaltar){
            if(Input.GetKeyDown(KeyCode.Space)){
                anima.SetBool("salte", true);
                rb.AddForce(new Vector3(0,fuerzaDeSalto,0), ForceMode.Impulse);
            }
            anima.SetBool("tocoSuelo", true);
        }else{
            estoyCayendo();
        }
    }

    public void estoyCayendo(){
        anima.SetBool("tocoSuelo",false);
        anima.SetBool("salte",false);
    }
}
