using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public enum GizmoType { Nunca, soloSeleccionado, Siempre }

    public Boid prefab;                 //Objeto que ha de ser asociado en la escena como prefab de boid
    public float RadioSpawn = 10;       //Radio del spawner
    public int cantidad = 10;           //Numero a generar
    public Color color;                 //Colores para gizmos
    public GizmoType showSpawnRegion;   //Para mostrar la esfera del spawner

    void Awake()
    {
        for (int i = 0; i < cantidad; i++)
        {
            Vector3 pos = transform.position + Random.insideUnitSphere * RadioSpawn; //En la pos de su origen + un vector3 de direccion aleatorio a un radio dentro del spawn area
            Boid boid = Instantiate(prefab);                                         //Instancia el prefab dado
            boid.transform.position = pos;                                           //En la pos dada
            boid.transform.forward = Random.insideUnitSphere;                        //Con la dir aleatoria

            boid.SetColor(color);                                                   //Debug para saber cual es cual
        }
    }

    /// <summary>
    /// En adelante solo para pintar gizmos de Unity segun opciones
    /// </summary>

    private void OnDrawGizmos()
    {
        if (showSpawnRegion == GizmoType.Siempre)
        {
            DrawGizmos();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (showSpawnRegion == GizmoType.soloSeleccionado)
        {
            DrawGizmos();
        }
    }

    void DrawGizmos()
    {

        Gizmos.color = new Color(color.r, color.g, color.b, 0.3f);
        Gizmos.DrawSphere(transform.position, RadioSpawn);
    }

}