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

    public static FrimeController head;

    protected override string SoilderName
    {
        get
        {
            return "Frime";
        }
    }

    void Start()
    {
        if(head != null)
        {
            Destroy(this.gameObject);
        }

        head = this;

        SpawnMySoilder();
        SetPattern();
        CreatePooling(10);
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
            GameObject obj = Instantiate(frime, new Vector3(-27 , 0 , 90), Quaternion.identity);
            Frime clone = obj.GetComponent<Frime>();
            clone.firstPosition = new Vector3(startSpawnPoint.x + i * distance, startSpawnPoint.y, startSpawnPoint.z);
            soilders.Add(clone);
            obj.name = MakeSoilderName(SoilderName, i);
           
        }
       

        for(int i = straightCount + 1 ; i <= count; i++)
        {
            GameObject obj = Instantiate(frime, new Vector3(27 , 0, 90), Quaternion.identity);
            Frime clone = obj.GetComponent<Frime>();
            clone.firstPosition = new Vector3(startSpawnPoint.x + (i - straightCount) * distance, startSpawnPoint.y - distance, startSpawnPoint.z);
            soilders.Add(clone);
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
