using UnityEngine;
using System.Collections;

public class Bola : MonoBehaviour {

    public Vector3 impulsoIni;
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(impulsoIni,ForceMode.Impulse);

	}
	
	// Update is called once per frame
	void Update () {
           
	}
}
