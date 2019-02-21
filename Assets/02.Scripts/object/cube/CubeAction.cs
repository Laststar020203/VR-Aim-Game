using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAction : MonoBehaviour {


    public float speed;
    public float rotateSpeed;

    public GameObject expParticle;

    Transform tr;

    Vector3 distance;
    Vector3 location;

    public int LimitX;
    public int LimitY;
    public int LimitZ;



    public int score = 0;

    private void Awake()
    {
        EventManager.AddListener<CollectObjectHitEvent>(HitbyPlayerAction);

    }
    void Start()
    {
       

        tr = GetComponent<Transform>();
        SetIrregularRotate();
    }

    void Update()
    {

        

        if (!((tr.position.x >= -LimitX && tr.position.x <= LimitX) &&
            (tr.position.z >= -LimitZ && tr.position.z <= LimitZ) &&
                (tr.position.y <= LimitY && tr.position.y >= 2)))
        {


            DistanceChange();
        }

       

        Move();
        Rotate();
    }

    
    private void SetIrregularDistance()
    {
        
        Vector3 newVector = new Vector3(((Random.Range(0, 2) == 0) ? 1 : -1), ((Random.Range(0, 2) == 0) ? 1 : -1), ((Random.Range(0, 2) == 0) ? 1 : -1));

    
        this.distance = newVector;

       
    }
    

    private void SetIrregularRotate()
    {
        Vector3 newVector = new Vector3(Random.Range(-350, 350), Random.Range(-350, 350), Random.Range(-350, 350));

        this.location = newVector;
        //tr.rotation = Quaternion.Euler(newVector);
    }

    private void Move()
    {
        tr.Translate(distance * Time.deltaTime * (speed * score * 0.01f));

    }


    private void Rotate()
    {
        tr.rotation = Quaternion.Slerp(tr.rotation, Quaternion.Euler(location), Time.deltaTime * rotateSpeed);
    }
    

    private void DistanceChange()
    {
        
        tr.position = new Vector3(
                ((Mathf.Sign(tr.position.x) == 1) ? tr.position.x -  0.2f : tr.position.x + 0.2f),
                (tr.position.y < 2 ? tr.position.y + 0.5f : (tr.position.y > LimitY ? tr.position.y - 0.5f : tr.position.y)),
                ((Mathf.Sign(tr.position.z) == 1) ? tr.position.z - 0.2f : tr.position.z + 0.2f)
                );

        this.distance = -distance;
        SetIrregularRotate();
      
        
       
    }


    public void HitbyPlayerAction(CollectObjectHitEvent e)
    {
        

        
        GameObject obj = Instantiate(expParticle, e.HitPoint, Quaternion.identity);
        Destroy(obj, 0.2f);

      
        score++;
        SetIrregularDistance();
    }

    
}
