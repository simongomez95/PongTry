using UnityEngine;
using System.Collections;



public class Jugador : MonoBehaviour {

    public float vel = 20;

    void Update ()
    {
        float velInput = 0f;

        velInput = Input.GetAxisRaw("Jugador");

        transform.position += new Vector3(velInput * vel * Time.deltaTime, 0f, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bola")
        {
            collision.rigidbody.AddForce(collision.rigidbody.velocity.normalized * (float)1.5, ForceMode.Impulse);
        }
    }
}
