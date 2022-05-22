using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour
{

    public GameObject deadSpawner;
    public BoidManager BM;

    public bool predator = false;

    float changeTime = 10.0f;

    float movementSpeed = 1.0f;

    float movementChance = 50.0f;

    public float movementMin = 0.1f;
    public float movementMax = 1.0f;

    float randomX = 0;
    float randomY = 0;
    float randomZ = 0;

    Vector3 sharkVector = new Vector3(0, 0, 0);

    void Start()
    {
       
    }

    void Update()
    {
        
        if (movementChance > 25)
        {
            movementSpeed = Random.Range(movementMin, movementMax);
            transform.position += Vector3.forward * 0.0f * movementSpeed;
        }

       
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
          
            if (hit.transform.name == "wall")
            {
                transform.position += Vector3.back * Time.deltaTime * movementSpeed;
            }
            
            if (hit.transform.tag == "obstacle")
            {
                transform.position += Vector3.back * Time.deltaTime * movementSpeed;
            }
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "fish")
        {
            BM.DestroyFish(collision);
            Destroy(collision.gameObject);
            callDead();
        }

    }
    

    public void callDead()
    {
        deadSpawner.GetComponent<DeadSpawner>().Spawn();
    }
}