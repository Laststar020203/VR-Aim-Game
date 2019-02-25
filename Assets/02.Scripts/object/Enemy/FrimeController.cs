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

    protected override string SoilderName
    {
        get
        {
            return "Frime";
        }
    }

    void Start()
    {
        SpawnMySoilder();
        SetPattern();

        StartCoroutine(Play());
    }

    void Update()
    {
        
    }


    protected override void SpawnMySoilder()
    {
        int straightCount = count / 2;
        

       

        for(int i = 1; i <= straightCount; i++)
        {
            GameObject obj = Instantiate(frime, new Vector3(startSpawnPoint.x + i*distance , startSpawnPoint.y , startSpawnPoint.z), Quaternion.identity);
            soilders.Add(obj.GetComponent<Frime>());
            obj.name = MakeSoilderName(SoilderName, i);
           
        }
       

        for(int i = straightCount + 1 ; i <= count; i++)
        {
            GameObject obj = Instantiate(frime, new Vector3(startSpawnPoint.x + (i - straightCount) * distance, startSpawnPoint.y - distance, startSpawnPoint.z), Quaternion.identity);
            soilders.Add(obj.GetComponent<Frime>());
            obj.name = MakeSoilderName(SoilderName, i);
        }

    }

    

    
    private IEnumerator FrimeOrder() {

        while (!isDie)
        {
            
            state = State.TRIANGLE;
            Order(2, 2, 10);


            yield return new WaitForSeconds(2.0f);
        }
    }

    protected override void SetPattern()
    {
        
        pattern.Enqueue(new EnemyAttack<State>(State.TRIANGLE , new float[] {2f ,0.2f , 1f, 20f }));
    }

    protected override IEnumerator Play()
    {
        while (!isDie)
        {
            if (isSolidersCompelete())
            {
                EnemyAttack<State> p = (EnemyAttack<State>)pattern.Dequeue();
                state = p.Name;
                yield return new WaitForSeconds(p.Value[0]);
                Order(p.Value[1], p.Value[2], p.Value[3]);
                pattern.Enqueue(p);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
