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
		if(bola.transform.position.x >= transform.position.x && Mathf.Abs(bola.transform.position.z-paleta.transform.position.z) <= 30){
			transform.position += new Vector3(0.5f, 0f, 0f);
		}
		if(bola.transform.position.x <= transform.position.x && Mathf.Abs(bola.transform.position.z-paleta.transform.position.z) <= 30){
			transform.position -= new Vector3(0.5f, 0f, 0f);
		}
	}
}
