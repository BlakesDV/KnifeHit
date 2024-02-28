using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGen : MonoBehaviour
{
    public List<ScriptablesObjects> patrones;
    public GameController controller;
    public PlanetRotation planet;
    
    // Start is called before the first frame update
    void Start()
    {
        ScriptablesObjects currentPattern;
        currentPattern = RandomPattern();
        controller.patron = currentPattern;
        planet.patron = currentPattern;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ScriptablesObjects RandomPattern()
    {
        if(patrones.Count > 0)
        {
            int randomIndex = Random.Range(0, patrones.Count);
            ScriptablesObjects patronRandom = patrones[randomIndex];
            return patronRandom;
        }

        return null;
    }
}
