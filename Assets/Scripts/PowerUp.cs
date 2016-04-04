using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	
	}
    
    void OnCollisionEnter(Collision coll) {
        
        if(coll.gameObject.tag == "Bola") {
            CampoJuego cj = GameObject.FindGameObjectWithTag("Field").GetComponent<CampoJuego>();
            cj.invertido = true;
            Destroy(gameObject);
        }
        
    }
}
