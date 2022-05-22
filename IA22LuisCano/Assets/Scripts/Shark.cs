using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour
{

    public GameObject deadSpawner;
    public BoidManager BM;


    
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