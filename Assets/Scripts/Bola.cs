using UnityEngine;
using System.Collections;

public class Bola : MonoBehaviour {

	public int velIni;
	public Puntaje puntos;
	public Rigidbody rb;
	public GameObject jugador1;
	public GameObject jugador2;
	public CampoJuego campo;

	// Use this for initialization
	void Start (){
        Spawnear();
	}

	void OnCollisionEnter(Collision col){
		Debug.Log (GetComponent<Rigidbody>().velocity);
		if(col.gameObject.gameObject == jugador1){
			Spawnear();
			puntos.puntaje1++;
		}else if(col.gameObject.gameObject == jugador2){
			Spawnear();
			puntos.puntaje2++;
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
		rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(impulsoIni,ForceMode.Impulse);
        
    }


}
