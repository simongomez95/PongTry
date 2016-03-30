using UnityEngine;
using System.Collections;

public enum ePlayer
{
    Left,
    Right
}

public class Jugador : MonoBehaviour {

    public float vel = 20;
    public ePlayer jugador;

    void Update () {
        float velInput = 0f;

        if (jugador == ePlayer.Right)
        {
            velInput = Input.GetAxisRaw("Jugador2");
        }
        else if (jugador == ePlayer.Left)
        {
            velInput = Input.GetAxisRaw("Jugador1");
        }

        transform.position += new Vector3(velInput * vel * Time.deltaTime, 0f, 0f);


    }
}
