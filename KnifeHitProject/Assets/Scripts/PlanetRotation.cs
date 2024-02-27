using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script w https://www.youtube.com/watch?v=GCBOp9vYTAs


public class PlanetRotation : MonoBehaviour
{
    [System.Serializable]
    private class RotationElement
    {
        #pragma warning disable 0649 
        public float Speed;
        public float Duration;
        #pragma warning restore 0649
    }

    [SerializeField]
    private RotationElement[] rotationPattern;

    private WheelJoint2D wheelJoint;
    private JointMotor2D motor;

    private void Awake()
    {
        wheelJoint = GetComponent<WheelJoint2D>();
        motor = new JointMotor2D();
        StartCoroutine("PlayRotationPattern");
    }

    private IEnumerator PlayRotationPattern()
    {
        int rotIndex = 0; 
        while(true) //infinite coroutine 
        {
            yield return new WaitForFixedUpdate(); //sincroniza la coroutine con el fixed update
            motor.motorSpeed = rotationPattern[rotIndex].Speed; 
            motor.maxMotorTorque = 1000; //valor del torque o giro
            wheelJoint.motor = motor; //mueve el wheel con el motor
            
            yield return new WaitForSecondsRealtime(rotationPattern[rotIndex].Duration); //waitforsecondsrealtime evita cambios de escala de tiempo, se basa en tiempo real
            rotIndex++;
            rotIndex = rotIndex < rotationPattern.Length ? rotIndex : 0; //regresa a 0 para hacer el loop, reinicia la rotacion
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
