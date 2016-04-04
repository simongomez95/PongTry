using UnityEngine;
using System.Collections;



public class Jugador : MonoBehaviour {

    public float vel = 60;
    public float percentDrop = 5f;
    
    public GameObject powerup;

    void Update ()
    {

        float input_x = Input.GetAxis("Horizontal");

        transform.position += new Vector3(input_x * vel * Time.deltaTime, 0f, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bola")
        {
            collision.rigidbody.AddForce(collision.rigidbody.velocity.normalized * 1.2f, ForceMode.Impulse);
            //Decidir si se crea o no powerup
            float rand = Random.Range(0f, 100f);
            if (rand < percentDrop) {
                InstanciarPowerup();
            }
        }
    }
    
    void InstanciarPowerup() {
        Instantiate(powerup, new Vector3(transform.position.x, transform.position.y,
         transform.position.z + Random.Range(5f, 32f)), Quaternion.identity);
    }
}
