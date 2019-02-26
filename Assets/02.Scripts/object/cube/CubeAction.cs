using UnityEngine;
using UnityEngine.EventSystems;

public class CubeAction : MonoBehaviour , IGvrPointerHoverHandler {


    public float speed;
    public float rotateSpeed;

    public GameObject expParticle;



    /*
    Vector3 distance;
    Vector3 location;

    public int LimitX;
    public int LimitY;
    public int LimitZ;
    */

    float nextTime;
    float coolTime = 0.1f;
    

    public int score = 0;

    //public Vector3 firstPosition;

    private void Awake()
    {
       

    }
    void Start()
    {
       

       
        //SetIrregularRotate();
        //firstPosition = tr.position;
    }

    public void OnGvrPointerHover(PointerEventData eventData)
    {
        if (Time.time >= nextTime)
        {

            GameObject obj = Instantiate(expParticle, eventData.pointerCurrentRaycast.worldPosition, Quaternion.identity);
            Destroy(obj, 0.2f);


            score++;
            

            nextTime = Time.time + coolTime;

        }
    }

    

    /*
    void Update()
    {

       
        
        if (!((tr.position.x >= -LimitX + firstPosition.x && tr.position.x <= LimitX + firstPosition.x) &&
            (tr.position.z >= -LimitZ + firstPosition.z && tr.position.z <= LimitZ + firstPosition.z) &&
                (tr.position.y <= LimitY + firstPosition.y && firstPosition.y >= 5)))
        {

            //tr.position = Vector3.Slerp(tr.position, firstPosition, Time.deltaTime * speed);
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

    */


}
