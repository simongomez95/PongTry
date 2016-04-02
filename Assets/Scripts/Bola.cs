using UnityEngine;
using System.Collections;

public class Bola : MonoBehaviour {

    public Vector3 impulsoIni;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        float velx = 10 + (10 * Random.value+0.1f);
        float velz = 10 + (10 * Random.value+0.1f);

        impulsoIni = new Vector3(velx,0,velz);

        rb = GetComponent<Rigidbody>();
        rb.AddForce(impulsoIni,ForceMode.Impulse);

	}
	
	// Update is called once per frame
	void Update () {
           
	}
}
