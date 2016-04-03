using UnityEngine;
using System.Collections;



public class Jugador : MonoBehaviour {

    public float vel = 50;

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
        }
    }
}
