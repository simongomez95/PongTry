using UnityEngine;
using System.Collections;

public enum ePlayer
{
    Left,
    Right
}

public class BordeGol : MonoBehaviour {

    public ePlayer jugador;
    public Puntaje puntaje;

	void OnCollisionEnter(Collision col)
    {
        Bola bola = col.gameObject.GetComponent<Bola>();
        if (bola != null)
        {
			float velx = 10 + (10 * (Random.value + 1f)) * ((Random.Range(0, 1) * 2 - 1));
			float velz = 10 + (10 * (Random.value + 1f)) * ((Random.Range(0, 1) * 2 - 1));

            Vector3 impulsoIni = new Vector3(velx, 0, velz);

            bola.transform.position = new Vector3(0f, 1f, 0f);

            bola.GetComponent<Rigidbody>().velocity = Vector3.zero;
            bola.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            bola.GetComponent<Rigidbody>().AddForce(impulsoIni, ForceMode.Impulse);

            if (jugador == ePlayer.Right)
            {
                puntaje.puntaje2++;    
            }
            else if (jugador == ePlayer.Left)
            {
                puntaje.puntaje1++;
            }

        }
    }
}
