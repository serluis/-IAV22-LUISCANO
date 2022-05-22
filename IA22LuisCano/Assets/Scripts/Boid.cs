using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    BoidOpciones opciones; //Para acceder a las opciones

    // estado inicial
    [HideInInspector]
    public Vector3 posicion; //posicion del GO
    [HideInInspector]
    public Vector3 forward;  //direccion forward del go
    Vector3 velocidad;        //velocidad

    // para actualizar
    Vector3 acceleration;
    [HideInInspector]
    public Vector3 dirMediaBanco;
    [HideInInspector]
    public Vector3 dirMediaEvasion;
    [HideInInspector]
    public Vector3 centroBanco;
    [HideInInspector]
    public int pecesBanco;

    
    Material material;
    Transform transformCache;  // tranform guardado en ram para rapido acceso
    Transform objetivo;

    void Awake () {
        material = transform.GetComponentInChildren<MeshRenderer> ().material; //para cambiar colores y demas
        transformCache = transform;
    }

    /// <summary>
    /// Utiliza los parametros de boidOpciones y el transform de la direccion objetivo
    /// </summary>
    public void IniciadorBoid (BoidOpciones opciones, Transform objetivo) {
        this.objetivo = objetivo;
        this.opciones = opciones;

        posicion = transformCache.position; //coge la pos del GO
        forward = transformCache.forward;   //coge la forward del GO

        float startSpeed = (opciones.velMin + opciones.velMax) / 2;
        velocidad = transform.forward * startSpeed;
    }

    public void SetColor (Color col) {
        if (material != null) {
            material.color = col;
        }
    }

    public void UpdateBoid () {
        Vector3 aceleracion = Vector3.zero;

        if (objetivo != null) {
            Vector3 vecDir = (objetivo.position - posicion);
            aceleracion = Girar (vecDir) * opciones.pesoObjetivo;
        }

        if (pecesBanco != 0) {
            centroBanco /= pecesBanco;

            Vector3 offsetToFlockmatesCentre = (centroBanco - posicion);

            var alignmentForce = Girar (dirMediaBanco) * opciones.pesoAlineamiento;
            var cohesionForce = Girar (offsetToFlockmatesCentre) * opciones.pesoCohesion;
            var seperationForce = Girar (dirMediaEvasion) * opciones.pesoSeparacion;

            aceleracion += alignmentForce;
            aceleracion += cohesionForce;
            aceleracion += seperationForce;
        }

        if (Chocar ()) {
            Vector3 collisionAvoidDir = DetectorParedes ();
            Vector3 collisionAvoidForce = Girar (collisionAvoidDir) * opciones.evasionCollPeso;
            aceleracion += collisionAvoidForce;
        }

        velocidad += aceleracion * Time.deltaTime;
        float speed = velocidad.magnitude;
        Vector3 dir = velocidad / speed;
        speed = Mathf.Clamp (speed, opciones.velMin, opciones.velMax);
        velocidad = dir * speed;

        transformCache.position += velocidad * Time.deltaTime;
        transformCache.forward = dir;
        posicion = transformCache.position;
        forward = dir;
    }
    Vector3 Girar (Vector3 vector) {
        Vector3 v = vector.normalized * opciones.velMax - velocidad;
        return Vector3.ClampMagnitude (v, opciones.fuerzaDirMax);
    }


    Vector3 DetectorParedes () {
        Vector3[] rayDir = BoidRayos.direcciones; // direcciones de los raycast

        for (int i = 0; i < rayDir.Length; i++) {
            Vector3 dir = transformCache.TransformDirection (rayDir[i]);
            Ray ray = new Ray (posicion, dir);
            if (!Physics.SphereCast (ray, opciones.radioLimites, opciones.distanciaEvasionColPeso, opciones.capaObstaculos)) {
                return dir;
            }
        }

        return forward;
    }
    bool Chocar () {
        RaycastHit hit;
        if (Physics.SphereCast (posicion, opciones.radioLimites, forward, out hit, opciones.distanciaEvasionColPeso, opciones.capaObstaculos)) {
            return true;
        } 
        else { }
        return false;
    }


}