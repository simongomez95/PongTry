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
            bola.Spawnear();

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
