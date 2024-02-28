using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script w https://www.youtube.com/watch?v=GCBOp9vYTAs
public class PlanetRotation : MonoBehaviour
{
    private WheelJoint2D wheelJoint;
    private JointMotor2D motor;
    public ScriptablesObjects patron;

    private void Awake()
    {
        wheelJoint = GetComponent<WheelJoint2D>();
        motor = new JointMotor2D();
        
    }

    void Update()
    {
        //booleano para revisar si ya inicio la coroutine
        if (patron != null)
        {
            StartCoroutine("PlayRotationPattern");
        }
    }

    private IEnumerator PlayRotationPattern()
    {
        int rotIndex = 0; 
        while(true) //infinite coroutine 
        {
            
                yield return new WaitForFixedUpdate(); //sincroniza la coroutine con el fixed update
                motor.motorSpeed = patron.rotationPattern[rotIndex].Speed;
                motor.maxMotorTorque = 1000; //valor del torque o giro
                wheelJoint.motor = motor; //mueve el wheel con el motor

                yield return new WaitForSecondsRealtime(patron.rotationPattern[rotIndex].Duration); //waitforsecondsrealtime evita cambios de escala de tiempo, se basa en tiempo real
                rotIndex++;
                rotIndex = rotIndex < patron.rotationPattern.Length ? rotIndex : 0; //regresa a 0 para hacer el loop, reinicia la rotacion

           
        }
    }

}
