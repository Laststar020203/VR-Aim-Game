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
        Vector3 newVector = new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));

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
        Debug.Log("DistanceChange");


        SetIrregularRotate();
        this.distance = -distance;
    }

    public void ClickAction()
    {
        score++;
        SetIrregularDistance();

        Debug.Log("Click!");
    }
}
