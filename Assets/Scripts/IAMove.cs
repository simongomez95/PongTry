using UnityEngine;
using System.Collections;

public class IAMove : MonoBehaviour {

	GameObject bola;
	GameObject paleta;

	// Use this for initialization
	void Start () {
		bola = GameObject.FindGameObjectWithTag("Bola");
		paleta = GameObject.FindGameObjectWithTag("PaletaIA");
	}
	
	// Update is called once per frame
	void Update ()  {
		if(bola.transform.position.x >= transform.position.x){
			transform.position += new Vector3(0.25f, 0f, 0f);
		}
		if(bola.transform.position.x <= transform.position.x){
			transform.position -= new Vector3(0.25f, 0f, 0f);
		}
	}
}
