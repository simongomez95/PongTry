using UnityEngine;
using System.Collections;

public class Bola : MonoBehaviour {

	public int velMax;
	public Puntaje puntos;
	public Rigidbody rb;
	public GameObject jugador1;
	public GameObject jugador2;
	public CampoJuego campo;

	// Use this for initialization
	void Start (){
        //posicionInicial = new Vector3(transform.position.x, transform.position.y, transform.position.z);
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
    
    public void Spawnear(){
		Vector3 inicial1 = new Vector3(0, 1, 0);
		Vector3 inicial2 = new Vector3(0, 18, 0);
		float velx = (velMax-3)*Random.value*(Random.Range(0, 2)*2-1);
		float velz = (velMax-Mathf.Abs(velx))*(Random.Range(0, 2)*2-1);

		if(campo.invertido){
			transform.position = inicial2;
		}else{
			transform.position = inicial1;
		}
        Vector3 impulsoIni = new Vector3(velx,0,velz);
		Debug.Log (impulsoIni);

		rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(impulsoIni,ForceMode.Impulse);
        
    }


}
