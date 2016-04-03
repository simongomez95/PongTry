using UnityEngine;
using System.Collections;

public class Bola : MonoBehaviour {

    public Vector3 impulsoIni;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        float velx = 10 + (10 * Random.value+0.1f);
        float velz = 10 + (10 * Random.value+0.1f);

        impulsoIni = new Vector3(velx,0,velz);

		rb = GetComponent<Rigidbody>();
        rb.AddForce(impulsoIni,ForceMode.Impulse);

	}

//	float hitFactor(Vector3 bola, Vector3 paleta, float anchoR){
//
//		return (bola.x - paleta.x) / anchoR;
//	}	
//	
//	void OnCollisionEnter(Collision col){
//		if(col.gameObject.name == "Jugador"){
//			float x = hitFactor (transform.position,col.transform.position,col.collider.bounds.size.x);
//
//			Vector3 dir = new Vector3 (1 + x, 1, -1).normalized;
//			GetComponent<Rigidbody> ().velocity = Vector3.Scale(GetComponent<Rigidbody> ().velocity , dir);
//		}
//
//		if(col.gameObject.name == "AI"){
//			float x = hitFactor (transform.position,col.transform.position,col.collider.bounds.size.x);
//
//			Vector3 dir = new Vector3 (1+ x, 1, 1).normalized;
//			GetComponent<Rigidbody> ().velocity = Vector3.Scale(GetComponent<Rigidbody> ().velocity , dir);
//		}
//	}
//
//
}
