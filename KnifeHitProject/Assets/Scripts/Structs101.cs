using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DatosDeJugador
{  
    public Transform position;
    int vida;

    public DatosDeJugador(Transform pos)
    {
        position = pos;
        vida = 0;
    }
}

public class Structs101 : MonoBehaviour
{
    DatosDeJugador datosJugador1;

    List<DatosDeJugador> jugadores = new List<DatosDeJugador>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 10; i++)
        {
            DatosDeJugador jugadorNuevo = new DatosDeJugador(transform);
            jugadores.Add(jugadorNuevo);
        }
    }
}
