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
        Vector3 impulsoIni;
        float velx = (velIni-3f)*Random.value*(Random.Range(0, 2f)*2f-1f);
		float velz = (velIni-Mathf.Abs(velx))*(Random.Range(0, 2f)*2f-1f);
		float z=0f;
		if(velx*velz>0f){
			if(velx<0f){
				z=15f;
			}
		}else{
			if(velz<0f){
				z=15f;
			}
		}
		Vector3 inicial1 = new Vector3(0f, 1f, z);
		Vector3 inicial2 = new Vector3(0f, 18f, z);

        //Se checkea si el campo esta invertido y no en modo brickbreaker
		if(campo.invertido && !campo.breaker){
			transform.position = inicial2;
		}else if(!campo.breaker){
			transform.position = inicial1;
		}

        //Si estamos en modo brickbreaker, envia la pelota hacia arriba
        if (!campo.breaker)
        {
            impulsoIni = new Vector3(velx, 0, velz);
        }
        else
        {
            impulsoIni = new Vector3(velx, velz, 0);
        }
        rb.velocity = Vector3.zero;
        rb.AddForce(impulsoIni,ForceMode.Impulse);
    }


}
