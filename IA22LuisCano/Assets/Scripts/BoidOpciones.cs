using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoidOpciones : ScriptableObject
{
    // Settings
    public float velMin = 2;
    public float velMax = 5;
    public float radioPerceptivo = 2.5f;
    public float radioEvasion = 1;
    public float maxSteerForce = 3;

    public float pesoAlineamiento = 1;
    public float pesoCohesion = 1;
    public float pesoSeparacion = 1;

    public float pesoObjetivo = 1;

    [Header("Colisiones")]
    public LayerMask obstacleMask;
    public float radioBordes = .27f;
    public float evasionCollPeso = 10;
    public float distanciaEvasionColPeso = 5;

}