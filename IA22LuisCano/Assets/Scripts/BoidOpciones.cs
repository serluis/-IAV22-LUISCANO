using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoidOpciones : ScriptableObject {
    // Opciones
    public float velMin = 2;
    public float velMax = 5;
    public float radioPercepcion = 2.5f;
    public float radioEvasion = 1;
    public float fuerzaDirMax = 3;

    public float pesoAlineamiento = 1;
    public float pesoCohesion = 1;
    public float pesoSeparacion = 1;

    public float pesoObjetivo = 1;

    [Header ("Colisiones")]
    public LayerMask capaObstaculos;
    public float radioLimites = .27f;
    public float evasionCollPeso = 10;
    public float distanciaEvasionColPeso = 5;

}
