using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour
{
    
    [HideInInspector]
    public Vector3 posicion; //posicion del GO
    [HideInInspector]
    public Vector3 forward;  //direccion forward del go
    Vector3 velocidad;        //velocidad
    public BoidOpciones opciones; //Para acceder a las opciones
    // para actualizar
    Vector3 acceleration;
    //Transform transformCache;  // tranform guardado en ram para rapido acceso
    Vector3 objetivo; //dir objetivo
    public float distVision = 10;
    //para generar peces y comer
    public GameObject deadSpawner;
    public BoidManager BM;
    public AudioSource nom;
    
    private void Awake()
    {
        //transformCache = transform;//asigna el transform
        posicion = transform.position;
    }
    private void Update()
    {
        Vector3 aceleracion = Vector3.zero;

        if (Chocar())
        {
            Vector3 collisionAvoidDir = DetectorParedes();
            Vector3 collisionAvoidForce = Girar(collisionAvoidDir) * opciones.evasionCollPeso;
            aceleracion += collisionAvoidForce;
        }
        //detectar peces


        if (objetivo != null)
        {
            Vector3 vecDir = DetectorPeces();
            aceleracion = Girar(vecDir) * opciones.pesoObjetivo*3; //vel x3 que si no es lento
        }

        velocidad += aceleracion * Time.deltaTime;
        float speed = velocidad.magnitude;
        Vector3 dir = velocidad / speed;
        speed = Mathf.Clamp(speed, opciones.velMin, opciones.velMax);
        velocidad = dir * speed;

        transform.position += velocidad * Time.deltaTime;
        transform.forward = dir;
        posicion = transform.position;
        forward = dir;
    }

    Vector3 DetectorPeces()
    {
        Vector3[] rayDir = BoidRayos.direcciones; // direcciones de los raycast
        RaycastHit hit;
        for (int i = 0; i < rayDir.Length; i++)
        {
            Vector3 dir = transform.TransformDirection(rayDir[i]);
            Ray ray = new Ray(posicion, dir);
            Physics.SphereCast(ray, distVision, out hit);

            if (hit.collider != null && hit.collider.gameObject.CompareTag("fish")) {
                Vector3 cazar = hit.collider.gameObject.transform.position - gameObject.transform.position;
                return Vector3.Normalize(cazar);
            }
        }
        return forward;
    }

    Vector3 Girar(Vector3 vector)
    {
        Vector3 v = vector.normalized * opciones.velMax - velocidad;
        return Vector3.ClampMagnitude(v, opciones.fuerzaDirMax);
    }
    bool Chocar()
    {
        RaycastHit hit;
        if (Physics.SphereCast(posicion, opciones.radioLimites, forward, out hit, opciones.distanciaEvasionColPeso, opciones.capaObstaculos))
        {
            return true;
        }
        else { }
        return false;
    }
    Vector3 DetectorParedes()
    {
        Vector3[] rayDir = BoidRayos.direcciones; // direcciones de los raycast

        for (int i = 0; i < rayDir.Length; i++)
        {
            Vector3 dir = transform.TransformDirection(rayDir[i]);
            Ray ray = new Ray(posicion, dir);
            if (!Physics.SphereCast(ray, distVision, opciones.distanciaEvasionColPeso, opciones.capaObstaculos))
            {
                return dir;
            }
        }

        return forward;
    }
    private void OnCollisionEnter(Collision collision) //comer
    {
        if(collision.gameObject.tag == "fish")
        {
            BM.DestroyFish(collision);
            Destroy(collision.gameObject);
            nom.Play();
            callDead();
        }

    }
    public void callDead() // llamar al generador
    {
        deadSpawner.GetComponent<DeadSpawner>().Spawn();
    }
}