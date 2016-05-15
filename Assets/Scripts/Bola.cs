using UnityEngine;
using System.Collections;

public class Bola : MonoBehaviour {

	public int velIni;
	public float velIncre;
	public Puntaje puntos;
	public Rigidbody rb;
	public GameObject IA;
	public GameObject player;
	public GameObject jugador1;
	public GameObject jugador2;
	public GameObject derecha;
	public GameObject izquierda;
	public CampoJuego campo;

	// Use this for initialization
	void Start (){
        Spawnear();
		rb = GetComponent<Rigidbody>();
	}

	void Update(){
		Debug.Log ("Velocidad: " + rb.velocity);
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.gameObject == jugador1){
			Spawnear();
			puntos.puntaje1++;
			return;
		}else if(col.gameObject.gameObject == jugador2){
			Spawnear();
			puntos.puntaje2++;
			return;
		}
	}

	void OnCollisionExit(Collision col){
		if(col.gameObject == IA){
			if(rb.velocity.x<0){
				rb.AddForce (new Vector3 (-velIncre, 0, -velIncre), ForceMode.VelocityChange);
			}else{
				rb.AddForce (new Vector3 (velIncre, 0, -velIncre), ForceMode.VelocityChange);
			}
		}else if(col.gameObject == player){
			if(rb.velocity.x<0){
				rb.AddForce (new Vector3 (-velIncre, 0, velIncre), ForceMode.VelocityChange);
			}else{
				rb.AddForce (new Vector3 (velIncre, 0, velIncre), ForceMode.VelocityChange);
			}
		}else if (col.gameObject.gameObject == izquierda) {
			if(rb.velocity.z<0){
				rb.AddForce (new Vector3 (velIncre, 0, -velIncre), ForceMode.VelocityChange);
			}else{
				rb.AddForce (new Vector3 (velIncre, 0, velIncre), ForceMode.VelocityChange);
			}
		}else if(col.gameObject.gameObject == derecha){
			if(rb.velocity.z<0){
				rb.AddForce (new Vector3 (-velIncre, 0, -velIncre), ForceMode.VelocityChange);
			}else{
				rb.AddForce (new Vector3 (-velIncre, 0, velIncre), ForceMode.VelocityChange);
			}
		}
	}
    
    public void Spawnear(){
		float velx = (velIni-3)*Random.value*(Random.Range(0, 2)*2-1);
		float velz = (velIni-Mathf.Abs(velx))*(Random.Range(0, 2)*2-1);
		float z=0;
		if(velx*velz>0){
			if(velx<0){
				z=15;
			}
		}else{
			if(velz<0){
				z=15;
			}
		}
		Vector3 inicial1 = new Vector3(0f, 1f, z);
		Vector3 inicial2 = new Vector3(0f, 18f, z);
		if(campo.invertido){
			transform.position = inicial2;
		}else{
			transform.position = inicial1;
		}
        Vector3 impulsoIni = new Vector3(velx,0,velz);
        rb.velocity = Vector3.zero;
        rb.AddForce(impulsoIni,ForceMode.Impulse);
    }


}
