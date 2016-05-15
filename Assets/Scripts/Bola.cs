using UnityEngine;
using System.Collections;

public class Bola : MonoBehaviour {

	Vector3 posicionInicial;
	public Puntaje puntos;
	public Rigidbody rb;
    public Vector3 impulsoIni;
	public GameObject jugador1;
	public GameObject jugador2;

	// Use this for initialization
	void Start () {
        posicionInicial = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Spawnear();

	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.gameObject == jugador1){
			Spawnear();
			puntos.puntaje1++;
		}else if(col.gameObject.gameObject == jugador2){
			Spawnear();
			puntos.puntaje2++;
		}
	}
    
    public void Spawnear() {
        
        transform.position = posicionInicial;
        //float velx = 10 + (10 * Random.value+0.1f);
        //float velz = 10 + (10 * Random.value+0.1f);

        float velx = (7 + (10 * (Random.value))) * ((Random.Range(0, 1) * 2 - 1));
        float velz = (7 + (10 * (Random.value))) * ((Random.Range(0, 1) * 2 - 1));


        impulsoIni = new Vector3(velx,0,velz);

		rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(impulsoIni,ForceMode.Impulse);
        
    }


}
