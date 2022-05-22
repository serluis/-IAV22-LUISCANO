using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSpawner : MonoBehaviour
{
    public BoidManager BM;
    public BoidOpciones opciones; //Para acceder a las opciones
    public GameObject prefab;                 //Objeto que ha de ser asociado en la escena como prefab de boid
    public float RadioSpawn = 10;       //Radio del spawner
    public int cantidad = 1;           //Numero a generar
    public Color color;

    public void Spawn()
    {
        Vector3 pos = transform.position + Random.insideUnitSphere * RadioSpawn; //En la pos de su origen + un vector3 de direccion aleatorio a un radio dentro del spawn area
        GameObject fish = Instantiate(prefab);                                   //Instancia el prefab dado
        fish.transform.position = pos;                                           //En la pos dada
        fish.transform.forward = Random.insideUnitSphere;                        //Con la dir aleatoria

        fish.GetComponent<Boid>().SetColor(color);
        fish.GetComponent<Boid>().IniciadorBoid(opciones, fish.transform);
        BM.AgregaPez(fish.GetComponent<Boid>());
    }
}
