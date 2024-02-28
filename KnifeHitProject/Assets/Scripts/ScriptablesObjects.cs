using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Patron", menuName = "ScriptableObjects/Patron", order = 0)]

public class ScriptablesObjects : ScriptableObject
{
    public int shipCount;

    public RotationElement[] rotationPattern;
}

[System.Serializable]
public class RotationElement
{
#pragma warning disable 0649
    public float Speed;
    public float Duration;
#pragma warning restore 0649
}
