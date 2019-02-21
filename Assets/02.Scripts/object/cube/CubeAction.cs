using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAction : MonoBehaviour {
    public float speed;

    Transform tr;

    Vector3 distance;
    Vector3 location;

    public int LimitX;
    public int LimitY;
    public int LimitZ;



    public int score = 0;

    void Start()
    {
        tr = GetComponent<Transform>();
        SetIrregularDistance();
    }

    void Update()
    {

        

        if (!((tr.position.x >= -LimitX && tr.position.x <= LimitX) &&
            (tr.position.z >= -LimitZ && tr.position.z <= LimitZ) &&
                (tr.position.y <= LimitY && tr.position.y >= 0)))
        {


            DistanceChange();
        }

       

        Move();
        Rotate();
    }

    private void SetIrregularDistance()
    {
        Vector3 newVector = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));

        SetIrregularRotate();

        this.distance = newVector;
    }

    private void SetIrregularRotate()
    {
        Vector3 newVector = new Vector3(Random.Range(-350, 350), Random.Range(-350, 350), Random.Range(-350, 350));

        this.location = newVector;
    }

    private void Move()
    {
        tr.Translate(distance * Time.deltaTime * speed * (score / 2));

    }

    private void Rotate()
    {
        tr.rotation = Quaternion.Slerp(tr.rotation, Quaternion.Euler(location), Time.deltaTime);
    }

    private void DistanceChange()
    {

        tr.position = new Vector3(
                ((Mathf.Sign(tr.position.x) == 1) ? tr.position.x - 0.1f : tr.position.x + 0.1f),
                ((Mathf.Sign(tr.position.y) == 1) ? tr.position.y - 0.1f : tr.position.y + 0.1f),
                ((Mathf.Sign(tr.position.z) == 1) ? tr.position.z - 0.1f : tr.position.z + 0.1f)
                );

        SetIrregularRotate();
        this.distance = -distance;
    }

    public void ClickAction()
    {
        score++;
        SetIrregularDistance();

    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("MainCamera"))
        {
            Debug.Log(coll.gameObject.name);
           
        }
    }

    private void HitbyPlayerAction(CollectObjectHitEvent e)
    {
       
    }

    
}
