using UnityEngine;
using System.Collections;

public class Ladrillo : MonoBehaviour {
	
	public Puntaje puntos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision coll) {
        
        if(coll.gameObject.tag == "Bola") {
			
            puntos.puntaje1++;
            Destroy(gameObject);
        }
        
    }
}
