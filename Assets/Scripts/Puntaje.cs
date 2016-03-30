using UnityEngine;
using System.Collections;

public class Puntaje : MonoBehaviour {

    public int puntaje1;
    public int puntaje2;
    public GUIStyle estilo;

    void Update()
    {
        string texto = puntaje1 + " - " + puntaje2;
        this.GetComponent<TextMesh>().text = texto;
    }

    /*void OnGUI()
    {
        float xMid = Screen.width / 2f;
        float yMid = 300f;

        float width = 300f;
        float height = 2000f;
        
        GUI.Label(new Rect(xMid - width / 2f, yMid, width, height), texto, estilo);
    }*/
}
