using UnityEngine;
using System.Collections;

public class Bola : MonoBehaviour {

    public Vector3 impulsoIni;
    Vector3 posicionInicial;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        posicionInicial = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Spawnear();

	}
    
    public void Spawnear() {
        
        transform.position = posicionInicial;
        float velx = 10 + (10 * Random.value+0.1f);
        float velz = 10 + (10 * Random.value+0.1f);

        impulsoIni = new Vector3(velx,0,velz);

		rb = GetComponent<Rigidbody>();
        rb.AddForce(impulsoIni,ForceMode.Impulse);
        
    }


}
