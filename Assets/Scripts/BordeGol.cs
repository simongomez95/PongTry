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
    public CampoJuego campoJuego;

	void OnCollisionEnter(Collision col)
    {
        Bola bola = col.gameObject.GetComponent<Bola>();
        if (bola != null)
        {
            
            campoJuego.invertido = false;
            StartCoroutine(SpawnearBola(bola));
            

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
    
    IEnumerator SpawnearBola(Bola bola) {
        
        yield return new WaitForSeconds(0.1f);
        bola.Spawnear();
    }
}
