using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoidRayos {

    const int numRayos = 300;
    public static readonly Vector3[] direcciones;

    static BoidRayos () {
        direcciones = new Vector3[BoidRayos.numRayos];

        //Formulas del golden ratio aureas
        float goldenRatio = (1 + Mathf.Sqrt (5)) / 2;
        float incremAngulo = Mathf.PI * 2 * goldenRatio;

        for (int i = 0; i < numRayos; i++) {
            float t = (float) i / numRayos;
            float inclinacion = Mathf.Acos (1 - 2 * t);
            float azimuth = incremAngulo * i;

            float x = Mathf.Sin (inclinacion) * Mathf.Cos (azimuth);
            float y = Mathf.Sin (inclinacion) * Mathf.Sin (azimuth);
            float z = Mathf.Cos (inclinacion);
            direcciones[i] = new Vector3 (x, y, z);
        }
    }

}