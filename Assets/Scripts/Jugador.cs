using UnityEngine;
using System.Collections;



public class Jugador : MonoBehaviour {

    public float vel = 60;
    public float percentDrop = 5f;
    public float percentBreak = 50f;
    public int dirR = -1;
    public int pasoR = 1;
    Vector3 posFinal, posActual;


    public GameObject powerup;
    
    public bool agrandado = false;

    void Update ()
    {

        float input_x = Input.GetAxis("Horizontal");

        transform.position += new Vector3(input_x * vel * Time.deltaTime, 0f, 0f);
        
        if(agrandado) {
            transform.localScale = new Vector3(8f, transform.localScale.y, transform.localScale.z);
            StartCoroutine(DesAgrandar());
        }
        else {
            transform.localScale = new Vector3(4f, transform.localScale.y, transform.localScale.z);
        }
    }

    void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.name == "Bola") {

            float rand = Random.Range(0f, 100f);

            //Decidir si cambia al breakout
            /*
            if (rand < percentBreak) {
                collision.rigidbody.velocity = Vector3.zero;

                //calcula posición actual y final de rotacion de la paleta    
                posActual = transform.eulerAngles;
                posFinal.x = (posActual.x + (90 * dirR));

                //comienza a rotar
                StartCoroutine(CambiarEscena(collision.gameObject));          
            }
            */
            
            //Calculo nueva velocidad de la bola basada en las velocidades de la bola y la paleta al chocar
            /*
            var velo = collision.rigidbody.velocity;
            velo.x = (velo.x/2.0f) + (this.GetComponent<Rigidbody>().velocity.x+3.0f);
            collision.rigidbody.velocity = velo;
            Debug.Log(velo);
            Debug.Log("m"+this.GetComponent<Rigidbody>().velocity.x);
            */
            
            //codigo original de anadidura de fuerza
            //collision.rigidbody.AddForce(collision.rigidbody.velocity.normalized * 1.1f, ForceMode.Impulse);
            
            //Decidir si se crea o no powerup
            rand = Random.Range(0f, 100f);
            if (rand < percentDrop) {
                InstanciarPowerup();
            }
        }
    }

    
    
    void InstanciarPowerup() {
        Instantiate(powerup, new Vector3(transform.position.x, transform.position.y,
         transform.position.z + Random.Range(5f, 32f)), Quaternion.identity);
    }

    IEnumerator CambiarEscena(GameObject bola) {

        //suma paso a paso la rotacion cada frame
        posActual.x += (pasoR * dirR);
        transform.eulerAngles = posActual;

        //girar la bola alrededor del eje de la paleta
        Vector3 posBola = bola.transform.position;
        Vector3 posPal = transform.position;

        yield return new WaitForSeconds(0);

        //checkea si ya termino de rotar tanto para en el sentido de las manecillas del reloj como en contra
        if ((int)posActual.x > (int)posFinal.x || (int)posActual.x > (int)posFinal.x) {
            StartCoroutine(CambiarEscena(bola));
        }

    }

    IEnumerator DesAgrandar() {
        
        yield return new WaitForSeconds(5);
        
        agrandado = false;
        
    }
}
