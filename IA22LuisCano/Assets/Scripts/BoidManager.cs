using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour {

    const int threadGroupSize = 1024; //numero de hilos

    public BoidOpciones opciones; // acceso a las opciones
    public ComputeShader compute; // un programa en hlsl para direct x que potencia para no usar <GameComponent>()
    List<Boid> boids = new List<Boid>();                   
                       

    void Start () {

        boids.AddRange(FindObjectsOfType<Boid>()); 
        foreach (Boid b in boids) {
            b.IniciadorBoid (opciones, null);//los inicia
        }

    }

    void Update () {
        if (boids != null) { //siempre que haya al menos uno

            int numBoids = boids.Count;
            var boidData = new BoidData[numBoids]; //array de datos de cada boid

            for (int i = 0; i < boids.Count; i++) { //Asigna cada direccion a cada boid
                boidData[i].posicion = boids[i].posicion;
                boidData[i].direccion = boids[i].forward;
            }

            var boidBuffer = new ComputeBuffer (numBoids, BoidData.Tam); //Metodo de unity engine para hacer threads para tratar la info
            boidBuffer.SetData (boidData);
            //Funciona en conjunto con el programa de hlsl
            compute.SetBuffer (0, "boids", boidBuffer);
            compute.SetInt ("numBoids", boids.Count);
            compute.SetFloat ("viewRadius", opciones.radioPercepcion);
            compute.SetFloat ("avoidRadius", opciones.radioEvasion);

            int threadGroups = Mathf.CeilToInt (numBoids / (float) threadGroupSize);
            compute.Dispatch (0, threadGroups, 1, 1);

            boidBuffer.GetData (boidData);

            for (int i = 0; i < boids.Count; i++) {
                boids[i].dirMediaBanco = boidData[i].dirBanco;
                boids[i].centroBanco = boidData[i].centroBanco;
                boids[i].dirMediaEvasion = boidData[i].dirEvasion;
                boids[i].pecesBanco = boidData[i].numPeces;

                boids[i].UpdateBoid ();
            }

            boidBuffer.Release ();
        }
    }

    public struct BoidData {
        public Vector3 posicion;
        public Vector3 direccion;

        public Vector3 dirBanco;
        public Vector3 centroBanco;
        public Vector3 dirEvasion;
        public int numPeces;

        public static int Tam {
            get {
                return sizeof (float) * 3 * 5 + sizeof (int); // Malla de datos 5 vectores3
            }
        }
    }

    public void AgregaPez(Boid b)
    {
        boids.Add(b);
    }
    public void DestroyFish(Collision col)
    {
        boids.Remove(col.gameObject.GetComponent<Boid>());
    }
}