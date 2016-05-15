using UnityEngine;
public class PowerUp : MonoBehaviour {
    
    public float percentDrop = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	
	}
    
    void OnCollisionEnter(Collision coll) {
        
        if(coll.gameObject.tag == "Bola") {
            
            float rand = Random.Range(0f, 100f);
            if (rand < percentDrop) {
                Invertir();
            }
            else {
                Agrandar();
            }
            
            Destroy(gameObject);
        }
        
    }

    private void Agrandar()
    {
        Jugador jugador = GameObject.FindGameObjectWithTag("Jugador1").GetComponent<Jugador>();
        jugador.agrandado = true;
        Debug.Log("Agrandar");
    }

    void Invertir() {
        CampoJuego cj = GameObject.FindGameObjectWithTag("Field").GetComponent<CampoJuego>();
        cj.invertido = true;
        Debug.Log("Invertir");    
    }
}
