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
		public GameObject derechaPong;
		public GameObject derechaBrick;
		public GameObject izquierdaPong;
		public GameObject izquierdaBrick;
		public CampoJuego campo;

		// Use this for initialization
		void Start (){
			Spawnear();
			rb = GetComponent<Rigidbody>();
		}

		void OnCollisionEnter(Collision col){
			if(col.gameObject == jugador1){
				Debug.Log("Pego contra mi gol");
				campo.breaker = false;
				Spawnear();
				puntos.puntaje1++;
				return;
			}else if(col.gameObject == jugador2){
				Spawnear();
				puntos.puntaje2++;
				return;
			}else if(col.gameObject.name == "PisoArena")
			{
				campo.breaker = false;
				GameObject.Find("GameObject").transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, transform.eulerAngles.z);
				Spawnear();
			}
		}

	void OnCollisionExit(Collision col){
		if (!campo.breaker) {
			if (col.gameObject == IA) {
				if (rb.velocity.x < 0) {
					rb.AddForce (new Vector3 (-velIncre, 0, -velIncre), ForceMode.VelocityChange);
				} else {
					rb.AddForce (new Vector3 (velIncre, 0, -velIncre), ForceMode.VelocityChange);
				}
			} else if (col.gameObject == player) {
				if (rb.velocity.x < 0) {
					rb.AddForce (new Vector3 (-velIncre, 0, velIncre), ForceMode.VelocityChange);
				} else {
					rb.AddForce (new Vector3 (velIncre, 0, velIncre), ForceMode.VelocityChange);
				}
			} else if (col.gameObject == izquierdaPong) {
				if (rb.velocity.z < 0) {
					rb.AddForce (new Vector3 (velIncre, 0, -velIncre), ForceMode.VelocityChange);
				} else {
					rb.AddForce (new Vector3 (velIncre, 0, velIncre), ForceMode.VelocityChange);
				}
			} else if (col.gameObject == derechaPong) {
				if (rb.velocity.z < 0) {
					rb.AddForce (new Vector3 (-velIncre, 0, -velIncre), ForceMode.VelocityChange);
				} else {
					rb.AddForce (new Vector3 (-velIncre, 0, velIncre), ForceMode.VelocityChange);
				}
			}
		} else {
			if (col.gameObject == izquierdaBrick) {
				if (rb.velocity.y < 0) {
					rb.AddForce (new Vector3 (velIncre, -velIncre, -0), ForceMode.VelocityChange);
				} else {
					rb.AddForce (new Vector3 (velIncre, velIncre, 0), ForceMode.VelocityChange);
				}
			} else if (col.gameObject == derechaBrick) {
				if (rb.velocity.y < 0) {
					rb.AddForce (new Vector3 (-velIncre, velIncre, -0), ForceMode.VelocityChange);
				} else {
					rb.AddForce (new Vector3 (-velIncre, -velIncre, 0), ForceMode.VelocityChange);
				}
			}
		}
		//Debug.Log ("Collider: " + col.gameObject);
		Debug.Log ("Vel: " + rb.velocity);
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
				GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezePositionY;
				transform.position = inicial2;

			}else if(!campo.breaker){
				GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
				transform.position = inicial1;
				Debug.Log("Aqui?");
			}

			//Si estamos en modo brickbreaker, envia la pelota hacia arriba
			if (!campo.breaker)
			{
				impulsoIni = new Vector3(velx, 0, velz);
				Debug.Log("Y aqui");
			}
			else
			{
				if(campo.invertido)
				{
					impulsoIni = new Vector3(velx, -velz, 0);
				}
				else
				{
					impulsoIni = new Vector3(velx, velz, 0);
				}

				Debug.Log("Entra");
			}
			rb.velocity = Vector3.zero;
			rb.AddForce(impulsoIni,ForceMode.Impulse);
			Debug.Log(impulsoIni.y);
			Debug.Log("vz" + velz);
		}


	}