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
        CreatePooling(10);
        SetPattern();
        
        StartCoroutine(Play());
        StartCoroutine(FrimeOrder());

        EventManager.AddListener<EnemyDeathEvent>(EnemyDeath);
        
    }

    void Update()
    {
        
    }


    protected override void SpawnMySoilder()
    {
        if (soilders.Count != 0) return;

        int straightCount = count / 2;
        int middle = straightCount / 2;

        for(int i = 1; i <= middle; i++)
        {
            int size = i % middle;
            GameObject obj = Instantiate(frime, new Vector3(-27 , 0 , 90), Quaternion.identity);
            Frime clone = obj.GetComponent<Frime>();
            clone.firstPosition = new Vector3(startSpawnPoint.x + size * distance, startSpawnPoint.y, startSpawnPoint.z);
            soilders.Add(clone);
            obj.name = MakeSoilderName(SoilderName, i);
           
        }

        for (int i = middle + 1; i <= straightCount; i++)
        {
            int size = i % middle;
            GameObject obj = Instantiate(frime, new Vector3(-27, 0, 90), Quaternion.identity);
            Frime clone = obj.GetComponent<Frime>();
            clone.firstPosition = new Vector3(startSpawnPoint.x + -(size * distance), startSpawnPoint.y, startSpawnPoint.z);
            soilders.Add(clone);
            obj.name = MakeSoilderName(SoilderName, i);

        }
        for (int i = straightCount + 1; i <= middle + straightCount; i++)
        {
            int size = i % middle;
            GameObject obj = Instantiate(frime, new Vector3(-27, 0, 90), Quaternion.identity);
            Frime clone = obj.GetComponent<Frime>();
            clone.firstPosition = new Vector3(startSpawnPoint.x + size * distance, startSpawnPoint.y - distance, startSpawnPoint.z);
            soilders.Add(clone);
            obj.name = MakeSoilderName(SoilderName, i);

        }

        for (int i = middle + straightCount + 1 ; i <= count; i++)
        {
            int size = i % middle;
            GameObject obj = Instantiate(frime, new Vector3(27 , 0, 90), Quaternion.identity);
            Frime clone = obj.GetComponent<Frime>();
            clone.firstPosition = new Vector3(startSpawnPoint.x + -(size * distance), startSpawnPoint.y - distance, startSpawnPoint.z);
            soilders.Add(clone);
            obj.name = MakeSoilderName(SoilderName, i);
        }

    }

     
    private IEnumerator FrimeOrder() {

        while (!isDie)
        {
            /*
            state = State.TRIANGLE;
            Order(2, 2, 10);
            */

            if(soilders.Count == 0)
            {
                SpawnMySoilder();
            }

            yield return new WaitForSeconds(0.1f);
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

    protected override void EnemyDeath(EnemyDeathEvent e)
    {
        if (e.DeathEnemy is Solider && soilders.Contains((Solider)e.DeathEnemy)) {
            int index = soilders.IndexOf((Solider)e.DeathEnemy);

            soilders.RemoveAt(index);
            GameObject obj = objPool[index];
            //objPool.Remove(obj);
            //Destroy(obj);
            Debug.Log(soilders.Count + "마리 남았다");
        }
        else
        {
            Debug.LogWarning("잘못된 엔티티가 넘어왔습니다.");
        }            
    }
}
