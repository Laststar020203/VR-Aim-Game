using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FrimeController : Boss
{
   

    public enum State {IDLE, TRIANGLE};

    public static State state;

    public Vector3 startSpawnPoint;

    public GameObject frime;

    public int count;
    public float distance;



    void Start()
    {
        SpawnMySoilder();        
    }

    void Update()
    {
        
    }


    protected override void SpawnMySoilder()
    {
        int straightCount = count / 2;
       
        for(int i = 0; i < straightCount; i++)
        {
            GameObject obj = Instantiate(frime, new Vector3(startSpawnPoint.x + i*distance , startSpawnPoint.y , startSpawnPoint.z), Quaternion.identity);
            soilders.Add(obj.GetComponent<Frime>());
        }

        for(int i = straightCount; i < count; i++)
        {
            GameObject obj = Instantiate(frime, new Vector3(startSpawnPoint.x + i * distance, startSpawnPoint.y + distance, startSpawnPoint.z), Quaternion.identity);
            soilders.Add(obj.GetComponent<Frime>());
        }
        
    }

    protected override void Order()
    {
        throw new System.NotImplementedException();
    }
}
